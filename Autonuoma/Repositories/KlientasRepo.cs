namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;

using Org.Ktu.Isk.P175B602.Autonuoma.Models;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.ModelioSpecifikacijos;


/// <summary>
/// Database operations related to 'Klientas' entity.
/// </summary>
public class KlientasRepo
{
    //public static List<Klientas> List()
    //{
    //	var query = $@"SELECT * FROM `klientai` ORDER BY id_klientas ASC";
    //	var drc = Sql.Query(query);

    //	var result = 
    //		Sql.MapAll<Klientas>(drc, (dre, t) => {
    //			t.Id = dre.From<int>("id_klientas");
    //			t.Vardas = dre.From<string>("Vardas");
    //			t.Pavarde = dre.From<string>("Pavarde");
    //			t.GimimoData = dre.From<DateTime>("Gimimo_data");
    //			t.Epastas = dre.From<string>("El_pastas");
    //		});

    //	return result;
    //}

    public static List<ModelioSpecifikacijos> List()
    {
        var query = $@"SELECT * FROM `modelio_specifikacijos` ORDER BY id_ ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<ModelioSpecifikacijos>(drc, (dre, t) =>
            {
                t.ID = dre.From<int>("id_");
                t.Pavadinimas = dre.From<string>("pavadinimas");
                t.VariklioTuris = dre.From<int>("variklio_turis");
                t.Galia = dre.From<int>("galia");
                t.KuroTipas = dre.From<int>("kuro_tipas");
                t.FkModelis = dre.From<int>("fk_Modelis");
            });

        return result;
    }

    //public static Klientas Find(int idklientas)
    //{
    //	var query = $@"SELECT * FROM `klientai` WHERE id_klientas=?idklientas";

    //	var drc =
    //		Sql.Query(query, args => {
    //			args.Add("?idklientas", idklientas);
    //		});

    //	if( drc.Count > 0 )
    //	{
    //		var result = 
    //			Sql.MapOne<Klientas>(drc, (dre, t) => {
    //				t.Id = dre.From<int>("id_klientas");
    //				t.Vardas = dre.From<string>("Vardas");
    //				t.Pavarde = dre.From<string>("Pavarde");
    //				t.GimimoData = dre.From<DateTime>("Gimimo_data");
    //				t.Epastas = dre.From<string>("El_pastas");
    //			});

    //		return result;
    //	}

    //	return null;
    //}

    public static ModelioSpecifikacijos Find(int id)
    {
        var query = $@"SELECT * FROM `modelio_specifikacijos` WHERE id_=?id";

        var drc =
            Sql.Query(query, args =>
            {
                args.Add("?id", id);
            });

        if (drc.Count > 0)
        {
            var result =
                Sql.MapOne<ModelioSpecifikacijos>(drc, (dre, t) =>
                {
                    t.ID = dre.From<int>("id_");
                    t.Pavadinimas = dre.From<string>("pavadinimas");
                    t.VariklioTuris = dre.From<int>("variklio_turis");
                    t.Galia = dre.From<int>("galia");
                    t.KuroTipas = dre.From<int>("kuro_tipas");
                    t.FkModelis = dre.From<int>("fk_Modelis");
                });

            return result;
        }

        return null;
    }

    public static void Insert(Klientas klientas)
    {
        var query =
            $@"INSERT INTO `klientai`
			(
				Vardas,
				Pavarde,
				Gimimo_data,
				El_pastas
			)
			VALUES(
				?vardas,
				?pavarde,
				?gimdata,
				?email
			)";

        Sql.Insert(query, args =>
        {
            args.Add("?vardas", klientas.Vardas);
            args.Add("?pavarde", klientas.Pavarde);
            args.Add("?gimdata", klientas.GimimoData);
            args.Add("?email", klientas.Epastas);
        });
    }

    public static void Update(Klientas klientas)
    {
        var query =
            $@"UPDATE `klientai`
			SET
				Vardas=?vardas,
				Pavarde=?pavarde,
				Gimimo_data=?gimdata,
				El_pastas=?email
			WHERE
				id_klientas=?idklientas";

        Sql.Update(query, args =>
        {
            args.Add("?idklientas", klientas.Id);
            args.Add("?vardas", klientas.Vardas);
            args.Add("?pavarde", klientas.Pavarde);
            args.Add("?gimdata", klientas.GimimoData);
            args.Add("?email", klientas.Epastas);
        });
    }

    public static void Delete(int id)
    {
        var query = $@"DELETE FROM `klientai` WHERE id_klientas=?id";
        Sql.Delete(query, args =>
        {
            args.Add("?id", id);
        });
    }
}
