using InternalWebSiteStats.DAL;
using InternalWebSiteStats.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InternalWebSiteStats
{
    public partial class Femminile : System.Web.UI.Page
    {
        SqlDal_Mongo_Hema mHemaEngine = new SqlDal_Mongo_Hema();
        private int tournamentId;
        private Tournament tournament;
        private int pools;

        protected void Page_Load(object sender, EventArgs e)
        {
            tournamentId = Convert.ToInt32(ConfigurationManager.AppSettings["Femminile"]);

            tournament = mHemaEngine.LoadTorunamentsDesc(tournamentId);

            if(tournament == null)
                return;

            lblTitle.Text = tournament.Name;

            pools = this.tournament.Pools;

            SetPools();
        }

        private void SetStats()
        {
            var stats = mHemaEngine.LoadStats(tournamentId);

            statsDataGrid.DataSource = stats;
            statsDataGrid.DataBind();

            gridPanel.Controls.Clear();

            lblTitle.Text = "<h3>Statistics</h3></br>" + this.tournament.Name;
        }

        private void SetPools()
        {
            var matches = mHemaEngine.LoadPoolsMatches(tournamentId);

            statsDataGrid.DataSource = null;
            statsDataGrid.DataBind();

            //poolsDataGrid.DataSource = matches;
            //poolsDataGrid.DataBind();

            for (int i = 0; i < pools; i++)
            {
                GridView gv = new GridView();
                gv.DataSource = matches.Where(x => x.Pool == i + 1).ToList();
                gv.DataBind();
                gv.CssClass = "table table-condensed table-hover";
                gridPanel.Controls.Add(gv);

                Label lbl = new Label();
                lbl.Text = "</br>";
                gridPanel.Controls.Add(lbl);

            }

            gridPanel.DataBind();

            lblTitle.Text = "<h3>Pools</h3></br>" + this.tournament.Name;
        }

        protected void btnStats_Click(object sender, EventArgs e)
        {
            if (tournament is null)
                return;

            SetStats();
        }

        protected void btnPools_Click(object sender, EventArgs e)
        {
            if (tournament is null)
                return;

            SetPools();
        }
    }
}