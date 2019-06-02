using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using GestionProjet.Models;


namespace System.Web.Mvc
{
    public static class DeleteProject
    {

        public static LogPrUsTskComb deleteProject(this HtmlHelper html, int projectId)
        {
            LogPrUsTskComb LogPrUsTskComb = new LogPrUsTskComb();

            Project project = new Project();

            return LogPrUsTskComb;
        }

        //<h1>@Html.deleteProject()</h1>
    }
}