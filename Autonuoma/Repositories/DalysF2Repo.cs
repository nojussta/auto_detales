namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Models.DalysF2;


/// <summary>
/// Database operations related to 'Sutartis' entity.
/// </summary>
public class DalysF2Repo
{
    public static List<DalysL> ListDalys()
    {
        var query =
            $@"SELECT
				d.id_ as id_,
				d.dalis as dalis,
				d.dalies_sritis as dalies_sritis,
				CONCAT(m.pavadinimas,' ',m.galia) as fk_Modelio_Specifikacija
			FROM
				`dalys` d
				LEFT JOIN `modelio_specifikacijos` m ON d.fk_Modelio_specifikacija=m.id_				
			ORDER BY id_ DESC";

        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<DalysL>(drc, (dre, t) =>
            {
                t.ID = dre.From<int>("id_");
                t.Dalis = dre.From<string>("dalis");
                t.DaliesSritis = dre.From<string>("dalies_sritis");
                t.FkSpec = dre.From<string>("fk_Modelio_specifikacija");
            });

        return result;
    }

    public static DalysCE FindDalisCE(int id)
    {
        var query = $@"SELECT * FROM `dalys` WHERE id_=?id";
        var drc =
            Sql.Query(query, args =>
            {
                args.Add("?id", id);
            });

        var result =
            Sql.MapOne<DalysCE>(drc, (dre, t) =>
            {
                //make a shortcut
                var uzs = t.Dalis;

                uzs.ID = dre.From<int>("id_");
                uzs.Dalis = dre.From<string>("dalis");
                uzs.DaliesSritis = dre.From<string>("dalies_sritis");
                uzs.FkSpec = dre.From<string>("fk_Modelio_specifikacija");
            });

        return result;
    }

    public static int InsertDalis(DalysCE uzsCE)
    {
        var query =
            $@"INSERT INTO `dalys`
			(
				`dalis`,
				`dalies_sritis`,
				`fk_Modelio_specifikacija`
			)
			VALUES(
				?insdalis,
				?insdalsritis,
				?insfkspec
			)";

        var id =
            Sql.Insert(query, args =>
            {
                //make a shortcut
                var uzs = uzsCE.Dalis;

                args.Add("?insdalis", uzs.Dalis);
                args.Add("?insdalsritis", uzs.DaliesSritis);
                args.Add("?insfkspec", uzs.FkSpec);
            });

        return (int)id;
    }

    public static void UpdateDalis(DalysCE uzsCE)
    {
        var query =
            $@"UPDATE `dalys`
			SET
				`dalis` = ?insdalis,
				`dalies_sritis` = ?insdalsritis,
				`fk_Modelio_specifikacija` = ?insfkspec
			WHERE id_=?id";

        Sql.Update(query, args =>
        {
            //make a shortcut
            var uzs = uzsCE.Dalis;

            args.Add("?insdalis", uzs.Dalis);
            args.Add("?insdalsritis", uzs.DaliesSritis);
            args.Add("?insfkspec", uzs.FkSpec);
            args.Add("?id", uzs.ID);
        });
    }

    public static void DeleteDalis(int id)
    {
        var query = $@"DELETE FROM `dalys` where id_=?id";
        Sql.Delete(query, args =>
        {
            args.Add("?id", id);
        });
    }

    public static List<DalysCE.PadalinysM> ListPasirinktiPadaliniai(int DalisId)
    {
        var query =
            $@"SELECT *
			FROM 
				`priklauso_padaliniui` pb
				LEFT JOIN `padaliniai` p ON pb.fk_Padalinys=p.id
			WHERE fk_Dalis = ?daliesID
			ORDER BY fk_Padalinys ASC";

        var drc =
            Sql.Query(query, args =>
            {
                args.Add("?daliesID", DalisId);
            });

        var result =
            Sql.MapAll<DalysCE.PadalinysM>(drc, (dre, t) =>
            {
                t.Padalinys =
                    //we use JSON here to make serialization/deserializaton of composite key more convenient
                    JsonConvert.SerializeObject(new
                    {
                        FKPadalinys = dre.From<int>("fk_Padalinys")
                    });
                t.Data = dre.From<DateTime>("data");
            });

        for (int i = 0; i < result.Count; i++)
            result[i].InListId = i;

        return result;
    }

    public static void InsertPasirinktiPadaliniai(int DalisId, DalysCE.PadalinysM up)
    {
        //deserialize 'Paslauga' foreign keys from 'UzsakytaPaslauga' view model key
        var fks =
            JsonConvert.DeserializeAnonymousType(
                up.Padalinys,
                //this creates object of correct shape that is filled in by the JSON deserializer
                new
                {
                    FKPadalinys = 0
                }
            );

        var query =
            $@"INSERT INTO `priklauso_padaliniui`
				(
					data,
					fk_Padalinys,
					fk_Dalis
				)
				VALUES(
					?data,
					?fkPad,
					?fkDal
				)";

        Sql.Insert(query, args =>
        {
            args.Add("?data", up.Data);
            args.Add("?fkPad", fks.FKPadalinys);
            args.Add("?fkDal", DalisId);
        });
    }

    public static void DeletePasirinktiPadaliniaiByDalis(int Dalis)
    {
        var query =
            $@"DELETE FROM pb
			USING `priklauso_padaliniui` as pb
			WHERE pb.fk_Dalis=?id";

        Sql.Delete(query, args =>
        {
            args.Add("?id", Dalis);
        });
    }
}