using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Table taskTabel = new Table();         

            TaskPanel.Visible = true;
                   
           AddRow(taskTabel, 1, "test1", "desc", "10/11/2015", "15/12/2015", "ToDo");
        }

        private void AddRow(Table taskTabel, int id, string title, string description, string date, string dueDate, string status)
        {
            TableRow tRow = new TableRow();
            taskTabel.Rows.Add(tRow);
            TaskPanel.Controls.Add(taskTabel);
            TableCell tCell = new TableCell();
            tRow.Cells.Add(tCell);
            AddCell(tCell, id + " ");
            AddCell(tCell, title + " ");
            AddCell(tCell, description + " ");
            AddCell(tCell, date + " ");
            AddCell(tCell, dueDate + " ");
            AddCell(tCell, status);
        }

        private static void AddCell(TableCell tCell, string value)
        {
            tCell.Controls.Add(new LiteralControl(value));
        }
    }
}