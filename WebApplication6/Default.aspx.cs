using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using test.DataAccess;
using test.DataAccess.Repository;

namespace WebApplication6
{
    public partial class _Default : Page
    {
        public class Book
        {
            public string Barcode { get; set; }
            public string BookName { get; set; }
            public string Author { get; set; }
            public string PublishingHouse { get; set; }
            public DateTime PublicationDate { get; set; }
            public int Price { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Program objProDB = new Program();
            objProDB.Main();
            rptVCard.DataSource = objProDB.GetBook();
            rptVCard.DataBind();

        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            pnlView.Visible = false;
            pnlEdit.Visible = true;
            Program objProDB = new Program();
            txtBarcode.Visible = false;
            txtBarcode.Text = objProDB.GetBookOne(hfBarcode.Value).Barcode;
            txtEdBknam.Text = objProDB.GetBookOne(hfBarcode.Value).BookName;
            txtEdAuthor.Text = objProDB.GetBookOne(hfBarcode.Value).Author;
            txtEdPublHouse.Text = objProDB.GetBookOne(hfBarcode.Value).PublishingHouse;
            txtEdPublDate.Text = objProDB.GetBookOne(hfBarcode.Value).PublicationDate.ToString();
            txtEdPrice.Text = objProDB.GetBookOne(hfBarcode.Value).Price.ToString();
        }
        protected void save_Click(object sender, EventArgs e)
        {
            if (txtBarcode.Visible == true) 
            { 
                Program objProDB = new Program();
                BookRepository2 book = new BookRepository2();
                book.Barcode = txtBarcode.Text;
                book.BookName = txtEdBknam.Text;
                book.Author = txtEdAuthor.Text;
                book.PublishingHouse = txtEdPublHouse.Text;
                book.PublicationDate = Convert.ToDateTime(txtEdPublDate.Text);
                book.Price = Convert.ToInt32(txtEdPrice.Text);
                objProDB.Create(book);
            }
            else
            {
                Program objProDB = new Program();
                BookRepository book = new BookRepository();
                book.BookName = txtEdBknam.Text;
                book.Author = txtEdAuthor.Text;
                book.PublishingHouse = txtEdPublHouse.Text;
                book.PublicationDate = Convert.ToDateTime(txtEdPublDate.Text);
                book.Price = Convert.ToInt32(txtEdPrice.Text);
                objProDB.uptBook(txtBarcode.Text, book);
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = true;
            pnlList.Visible = false;
            Program objProDB = new Program();
            txtBarcode.Visible = true;
            foreach (Control control in pnlEdit.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = string.Empty;
                }
            }

        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            pnlEdit.Visible = false;
            pnlView.Visible = false;
            pnlList.Visible = true;
        }
        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }
        protected void rptVCard_ItemCommand(object source, RepeaterCommandEventArgs e)//顯示隱藏區塊
        {
            Program objProDB = new Program();
            if (e.CommandName == "gvView")
            {
                pnlList.Visible = false;
                pnlView.Visible = true;
                txt_Barcode.Text = objProDB.GetBookOne(e.CommandArgument.ToString()).Barcode;
                hfBarcode.Value = txt_Barcode.Text;
                txt_BookName.Text = objProDB.GetBookOne(e.CommandArgument.ToString()).BookName;
                txt_Author.Text = objProDB.GetBookOne(e.CommandArgument.ToString()).Author;
                txt_PublishingHouse.Text = objProDB.GetBookOne(e.CommandArgument.ToString()).PublishingHouse;
                txt_PublicationDate.Text = objProDB.GetBookOne(e.CommandArgument.ToString()).PublicationDate.ToString();
                txt_Price.Text = objProDB.GetBookOne(e.CommandArgument.ToString()).Price.ToString();
            }
            else if (e.CommandName == "gvDel") 
            {
                objProDB.delBook(e.CommandArgument.ToString());
            }
        }
    }
}