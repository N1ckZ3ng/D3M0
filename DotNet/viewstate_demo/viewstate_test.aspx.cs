using System;

public partial class _Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            lblOutput.Text = ViewState["UserInput"] as string;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        ViewState["UserInput"] = txtInput.Text;
        
    }
}

