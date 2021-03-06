using BussinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStoreWinApp
{
    public partial class frmMemberDetail : Form
    {
        public frmMemberDetail()
        {
            InitializeComponent();
        }
        public IMemberRepository MemberRepository { get; set; }
        public bool InsertOrUpdate { get; set; }
        public MemberObject MemberInfo { get; set; }
        private void frmMemberDetail_Load(object sender, EventArgs e)
        {
            txtMemberID.Enabled = !InsertOrUpdate;
            if (InsertOrUpdate == true)
            {
                txtMemberID.Text = MemberInfo.MemberId.ToString();
                txtEmail.Text = MemberInfo.Email.ToString();
                txtCompanyName.Text = MemberInfo.CompanyName.ToString();
                txtCity.Text = MemberInfo.City.ToString();
                txtCountry.Text = MemberInfo.Country.ToString();
                txtPassword.Text = MemberInfo.Password.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var member = new MemberObject
                {
                    MemberId=int.Parse(txtMemberID.Text),
                    Email=txtEmail.Text,
                    CompanyName=txtCompanyName.Text,
                    City=txtCity.Text,
                    Country=txtCountry.Text,
                    Password=txtPassword.Text
                };
                if (InsertOrUpdate == false)
                {
                    MemberRepository.InsertMember(member);
                }
                else
                {
                    MemberRepository.UpdateMember(member);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new member" : "Update a member");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
