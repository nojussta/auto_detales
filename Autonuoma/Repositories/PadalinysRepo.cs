namespace Org.Ktu.Isk.P175B602.Autonuoma.Repositories;

using MySql.Data.MySqlClient;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Padaliniai;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.Paslauga;


/// <summary>
/// Database operations related to 'Paslauga' entity.
/// </summary>
public class PadalinysRepo
{
    public static List<Padalinys> List()
    {
        var query = $@"SELECT * FROM `padaliniai` ORDER BY id ASC";
        var drc = Sql.Query(query);

        var result =
            Sql.MapAll<Padalinys>(drc, (dre, t) =>
            {
                t.Id = dre.From<int>("id");
                t.Miestas = dre.From<string>("miestas");
                t.Busena = dre.From<bool>("busena");
            });

        return result;
    }
}
