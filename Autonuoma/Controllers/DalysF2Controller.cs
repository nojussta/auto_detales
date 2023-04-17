namespace Org.Ktu.Isk.P175B602.Autonuoma.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using Newtonsoft.Json;

using Org.Ktu.Isk.P175B602.Autonuoma.Repositories;
using Org.Ktu.Isk.P175B602.Autonuoma.Models.DalysF2;
using static Google.Protobuf.WellKnownTypes.Field.Types;
using Google.Protobuf.WellKnownTypes;


/// <summary>
/// Controller for working with 'Sutartis' entity. Implementation of F2 version.
/// </summary>
public class DalysF2Controller : Controller
{
    /// <summary>
    /// This is invoked when either 'Index' action is requested or no action is provided.
    /// </summary>
    /// <returns>Entity list view.</returns>
    [HttpGet]
    public ActionResult Index()
    {
        return View(DalysF2Repo.ListDalys());
    }

    /// <summary>
    /// This is invoked when creation form is first opened in a browser.
    /// </summary>
    /// <returns>Entity creation form.</returns>
    [HttpGet]
    public ActionResult Create()
    {
        var uzsCE = new DalysCE();

        //uzsCE.Dalis.UzsakymoData = DateTime.Now;

        PopulateLists(uzsCE);

        return View(uzsCE);
    }


    /// <summary>
    /// This is invoked when buttons are pressed in the creation form.
    /// </summary>
    /// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
    /// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
    /// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
    /// <param name="uzsCE">Entity view model filled with latest data.</param>
    /// <returns>Returns creation from view or redirets back to Index if save is successfull.</returns>
    [HttpPost]
    public ActionResult Create(int? save, int? add, int? remove, DalysCE uzsCE)
    {
        //addition of new 'UzsakytosPaslaugos' record was requested?
        if (add != null)
        {
            //add entry for the new record
            var up =
                new DalysCE.PadalinysM
                {
                    InListId =
                        uzsCE.PasirinktiPadaliniai.Count > 0 ?
                        uzsCE.PasirinktiPadaliniai.Max(it => it.InListId) + 1 :
                        0,

                    Data = DateTime.Now,
                    Padalinys = null,
                    //DaugiauVietosKojom = false,
                    //fkDalis = 0,
                    //Klase = null,
                };
            uzsCE.PasirinktiPadaliniai.Add(up);

            //make sure @Html helper is not reusing old model state containing the old list
            ModelState.Clear();

            //go back to the form
            PopulateLists(uzsCE);
            return View(uzsCE);
        }

        //removal of existing 'UzsakytosPaslaugos' record was requested?
        if (remove != null)
        {
            //filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
            uzsCE.PasirinktiPadaliniai =
                uzsCE
                    .PasirinktiPadaliniai
                    .Where(it => it.InListId != remove.Value)
                    .ToList();

            //make sure @Html helper is not reusing old model state containing the old list
            ModelState.Clear();

            //go back to the form
            PopulateLists(uzsCE);
            return View(uzsCE);
        }

        //save of the form data was requested?
        if (save != null)
        {

            //form field validation passed?
            if (ModelState.IsValid)
            {
                //create new 'Sutartis'
                uzsCE.Dalis.ID = DalysF2Repo.InsertDalis(uzsCE);

                //create new 'UzsakytosPaslaugos' records
                foreach (var upVm in uzsCE.PasirinktiPadaliniai)
                    DalysF2Repo.InsertPasirinktiPadaliniai(uzsCE.Dalis.ID, upVm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }
            //form field validation failed, go back to the form
            else
            {
                PopulateLists(uzsCE);
                return View(uzsCE);
            }
        }

        //should not reach here
        throw new Exception("Should not reach here.");
    }

    /// <summary>
    /// This is invoked when editing form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to edit.</param>
    /// <returns>Editing form view.</returns>
    [HttpGet]
    public ActionResult Edit(int id)
    {
        var uzsCE = DalysF2Repo.FindDalisCE(id);

        uzsCE.PasirinktiPadaliniai = DalysF2Repo.ListPasirinktiPadaliniai(id);
        PopulateLists(uzsCE);

        return View(uzsCE);
    }

    /// <summary>
    /// This is invoked when buttons are pressed in the editing form.
    /// </summary>
    /// <param name="id">ID of the entity being edited</param>
    /// <param name="save">If not null, indicates that 'Save' button was clicked.</param>
    /// <param name="add">If not null, indicates that 'Add' button was clicked.</param>
    /// <param name="remove">If not null, indicates that 'Remove' button was clicked and contains in-list-id of the item to remove.</param>
    /// <param name="uzsCE">Entity view model filled with latest data.</param>
    /// <returns>Returns editing from view or redired back to Index if save is successfull.</returns>
    [HttpPost]
    public ActionResult Edit(int id, int? save, int? add, int? remove, DalysCE uzsCE)
    {
        //addition of new 'UzsakytosPaslaugos' record was requested?
        if (add != null)
        {
            //add entry for the new record
            var up =
                new DalysCE.PadalinysM
                {
                    InListId =
                        uzsCE.PasirinktiPadaliniai.Count > 0 ?
                        uzsCE.PasirinktiPadaliniai.Max(it => it.InListId) + 1 :
                        0,

                    Data = DateTime.Now,
                    Padalinys = null,
                    //Data = DateTime.Now,
                    //fkPadalinys = 0,
                    //DaugiauVietosKojom = false,
                    //fkDalis = 0,
                    //Klase = null,
                };
            uzsCE.PasirinktiPadaliniai.Add(up);

            //make sure @Html helper is not reusing old model state containing the old list
            ModelState.Clear();

            //go back to the form
            PopulateLists(uzsCE);
            return View(uzsCE);
        }

        //removal of existing 'UzsakytosPaslaugos' record was requested?
        if (remove != null)
        {
            //filter out 'UzsakytosPaslaugos' record having in-list-id the same as the given one
            uzsCE.PasirinktiPadaliniai =
                uzsCE
                    .PasirinktiPadaliniai
                    .Where(it => it.InListId != remove.Value)
                    .ToList();

            //make sure @Html helper is not reusing old model state containing the old list
            ModelState.Clear();

            //go back to the form
            PopulateLists(uzsCE);
            return View(uzsCE);
        }

        //save of the form data was requested?
        if (save != null)
        {
            //form field validation passed?
            if (ModelState.IsValid)
            {
                //update 'Sutartis'
                DalysF2Repo.UpdateDalis(uzsCE);

                //delete all old 'UzsakytosPaslaugos' records
                DalysF2Repo.DeletePasirinktiPadaliniaiByDalis(uzsCE.Dalis.ID);

                //create new 'UzsakytosPaslaugos' records
                foreach (var upVm in uzsCE.PasirinktiPadaliniai)
                    DalysF2Repo.InsertPasirinktiPadaliniai(uzsCE.Dalis.ID, upVm);

                //save success, go back to the entity list
                return RedirectToAction("Index");
            }
            //form field validation failed, go back to the form
            else
            {
                PopulateLists(uzsCE);
                return View(uzsCE);
            }
        }

        //should not reach here
        throw new Exception("Should not reach here.");
    }

    /// <summary>
    /// This is invoked when deletion form is first opened in browser.
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view.</returns>
    [HttpGet]
    public ActionResult Delete(int id)
    {
        var uzsCE = DalysF2Repo.FindDalisCE(id);
        return View(uzsCE);
    }

    /// <summary>
    /// This is invoked when deletion is confirmed in deletion form
    /// </summary>
    /// <param name="id">ID of the entity to delete.</param>
    /// <returns>Deletion form view on error, redirects to Index on success.</returns>
    [HttpPost]
    public ActionResult DeleteConfirm(int id)
    {
        //load 'Sutartis'
        var sutCE = DalysF2Repo.FindDalisCE(id);

        try
        {
            //delete the entity
            DalysF2Repo.DeletePasirinktiPadaliniaiByDalis(id);
            DalysF2Repo.DeleteDalis(id);

            //redired to list form
            return RedirectToAction("Index");
        }

        catch
        {
            //enable explanatory message and show delete form
            ViewData["deletionNotPermitted"] = true;
            return View("Delete", sutCE);
        }
    }

    /// <summary>
    /// Populates select lists used to render drop down controls.
    /// </summary>
    /// <param name="sutCE">'Sutartis' view model to append to.</param>
    private void PopulateLists(DalysCE uzsCE)
    {
        //load entities for the select lists
        var klientai = KlientasRepo.List();


        //build select lists
        uzsCE.Lists.ModelioSpecifikacijos =
            klientai
                .Select(it =>
                {
                    return
                        new SelectListItem
                        {
                            Value = Convert.ToString(it.ID),
                            //Text = $"{it.Vardas} {it.Pavarde}"
                            Text = it.Pavadinimas
                        };
                })
                .ToList();


        //build select list for 'UzsakytosPaslaugos'
        {
            //initialize the destination list
            uzsCE.Lists.Padaliniai = new List<SelectListItem>();

            //load 'Paslaugos' to use for item groups
            var skrydziai = PadalinysRepo.List();

            //create select list items from 'PaslauguKainos' related to each 'Paslaugos'
            foreach (var skrydis in skrydziai)
            {
                //create list item group for current 'Paslaugos' entity
                var itemGrp = new SelectListGroup() { Name = skrydis.Id.ToString() };

                var sle =
                    new SelectListItem
                    {
                        Value =
                                //we use JSON here to make serialization/deserializaton of composite key more convenient
                                JsonConvert.SerializeObject(new
                                {
                                    //Data = skrydis.Miestas,
                                    FKPadalinys = skrydis.Id
                                }),
                        Text = $"Priklauso padaliniui {skrydis.Miestas}",
                        Group = itemGrp
                    };
                uzsCE.Lists.Padaliniai.Add(sle);
            }
        }
    }
}
