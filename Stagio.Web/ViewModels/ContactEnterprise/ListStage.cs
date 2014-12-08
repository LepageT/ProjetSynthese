using System;
using System.ComponentModel;
namespace Stagio.Web.ViewModels.ContactEnterprise
{
    public class ListStage
    {
    public int Id { get; set; }
    [DisplayName("Date de l'offre")]
    public String PublicationDate { get; set; }
    [DisplayName("Nombre de candidatures")]
    public int NbApply { get; set; }
    [DisplayName("Titre de l'offre")]
    public string StageTitle { get; set; }
    public int Status { get; set; }
    }
}