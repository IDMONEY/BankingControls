using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RAFClientDemo
{
    public partial class clientInfo : Form
    {
        int CustomerID = 0;
        RAFClientDemo.RafProxy.RAFProxy rproxy = new RAFClientDemo.RafProxy.RAFProxy();



        public clientInfo(int customer)
        {
            InitializeComponent();
            if (customer != 0)
            {
                CustomerID = customer;
                bindClientInfo();
                bindClientAssets();

            }//End if customer != 0

            //DataGridViewComboBoxColumn dropColAction = (DataGridViewComboBoxColumn)assetRulesdataGridView.Columns[0];
            //dropColAction.Items.Clear();
            //dropColAction.DataSource = commonMethods.getGuiDSData("actions").DataSet;
            //dropColAction.DisplayMember = "text";
            //dropColAction.ValueMember = "value";

            //DataGridViewComboBoxColumn dropColTran = (DataGridViewComboBoxColumn)assetRulesdataGridView.Columns[1];
            //dropColTran.Items.Clear();
            //dropColTran.DataSource = commonMethods.getGuiDSData("trantypeantypes").DataSet;
            //dropColTran.DisplayMember = "text";
            //dropColTran.ValueMember = "value";

        }

        private void clientInfo_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = false;
        }

        private void bindClientInfo()
        {
            DataSet DSClientInfo = new DataSet();
            try
            {
                DSClientInfo = rproxy.CustomerGetDetails(CustomerID, 2);
                if (
                    (DSClientInfo.Tables[0] != null) &&
                    (DSClientInfo.Tables[0].Rows.Count > 0)
                    )
                {

                    DataRow row = DSClientInfo.Tables[0].Rows[0];
                    RowWrapper wrapper = new RowWrapper(row);

                    wrapper.rowView.Row.Table.Columns["firstname"].ColumnName = "Nombre";
                    wrapper.rowView.Row.Table.Columns["middlename"].ColumnName = "Seg Nombre";
                    wrapper.rowView.Row.Table.Columns["surname1"].ColumnName = "Apellido";
                    wrapper.rowView.Row.Table.Columns["surname2"].ColumnName = "Seg Apellido";
                    wrapper.rowView.Row.Table.Columns["idnumber"].ColumnName = "Identificación";
                    wrapper.rowView.Row.Table.Columns["Country"].ColumnName = "País";
                    wrapper.rowView.Row.Table.Columns["name"].ColumnName = "Registrante";
                    wrapper.rowView.Row.Table.Columns["registrationdate"].ColumnName = "Matrícula";
                    wrapper.rowView.Row.Table.Columns["State"].ColumnName = "Estado";
                    wrapper.rowView.Row.Table.Columns["profilename"].ColumnName = "Perfil";
                    wrapper.rowView.Row.Table.Columns["language"].ColumnName = "Idioma";

                    ClientPropertyGrid.SelectedObject = wrapper;
                }
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }

        }

        private void bindClientAssets()
        {
            DataSet DSClientAssets = new DataSet();
            try
            {

                DSClientAssets = rproxy.CustomerGetAssets(CustomerID, 2);

                if (DSClientAssets.Tables[0].Rows.Count > 0)
                {
                    BindingSource dbBindSource = new BindingSource();
                    dbBindSource.DataSource = DSClientAssets.Tables[0];
                    assetsGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
                    assetsGridView1.ReadOnly = true;
                    assetsGridView1.DataSource = dbBindSource;

                    ///////// 
                    // Format
                    ///////// 

                    //Headers
                    assetsGridView1.Columns["assetID"].Visible = false;
                    assetsGridView1.Columns["assetNumber"].HeaderText = "Número";
                    assetsGridView1.Columns["assetType"].HeaderText = "Tipo";
                    assetsGridView1.Columns["assetState"].HeaderText = "Estado";

                    //Grid
                    //assetsGridView1.AllowUserToResizeColumns = true;
                    assetsGridView1.ReadOnly = true;
                    assetsGridView1.Rows[0].Selected = false;
                    //assetsGridView1.RowHeadersVisible = false;
                    //assetsGridView1.AutoSize = true;

                    //Columns
                    //assetsGridView1.Columns["CustName"].Width = 174;
                    //assetsGridView1.Columns["CustIDNumber"].Width = 173;
                    //assetsGridView1.Columns["assetNumber"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //assetsGridView1.Columns["assetType"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //assetsGridView1.Columns["assetState"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
            catch (Exception x)
            {
                x.Message.Trim();
            }
            assetsGridView1.Refresh();

        }

        [TypeConverter(typeof(RowWrapper.RowWrapperConverter))]
        class RowWrapper
        {
            private readonly List<string> exclude = new List<string>();
            public List<string> Exclude { get { return exclude; } }
            public readonly DataRowView rowView;
            public RowWrapper(DataRow row)
            {
                DataView view = new DataView(row.Table);
                foreach (DataRowView tmp in view)
                {
                    if (tmp.Row == row)
                    {
                        rowView = tmp;
                        break;
                    }
                }
            }
            static DataRowView GetRowView(object component)
            {
                return ((RowWrapper)component).rowView;
            }
            class RowWrapperConverter : TypeConverter
            {
                public override bool GetPropertiesSupported(ITypeDescriptorContext context)
                {
                    return true;
                }
                public override PropertyDescriptorCollection GetProperties(
                    ITypeDescriptorContext context, object value, Attribute[] attributes)
                {
                    RowWrapper rw = (RowWrapper)value;
                    PropertyDescriptorCollection props = TypeDescriptor.GetProperties(
                        GetRowView(value), attributes);
                    List<PropertyDescriptor> result = new List<PropertyDescriptor>(props.Count);
                    foreach (PropertyDescriptor prop in props)
                    {
                        if (rw.Exclude.Contains(prop.Name)) continue;
                        result.Add(new RowWrapperDescriptor(prop));
                    }
                    return new PropertyDescriptorCollection(result.ToArray());
                }
            }
            class RowWrapperDescriptor : PropertyDescriptor
            {
                static Attribute[] GetAttribs(AttributeCollection value)
                {
                    if (value == null) return null;
                    Attribute[] result = new Attribute[value.Count];
                    value.CopyTo(result, 0);
                    return result;
                }
                readonly PropertyDescriptor innerProp;
                public RowWrapperDescriptor(PropertyDescriptor innerProperty)
                    : base(
                        innerProperty.Name, GetAttribs(innerProperty.Attributes))
                {
                    this.innerProp = innerProperty;
                }


                public override bool ShouldSerializeValue(object component)
                {
                    return innerProp.ShouldSerializeValue(GetRowView(component));
                }
                public override void ResetValue(object component)
                {
                    innerProp.ResetValue(GetRowView(component));
                }
                public override bool CanResetValue(object component)
                {
                    return innerProp.CanResetValue(GetRowView(component));
                }
                public override void SetValue(object component, object value)
                {
                    innerProp.SetValue(GetRowView(component), value);
                }
                public override object GetValue(object component)
                {
                    return innerProp.GetValue(GetRowView(component));
                }
                public override Type PropertyType
                {
                    get { return innerProp.PropertyType; }
                }
                public override Type ComponentType
                {
                    get { return typeof(RowWrapper); }
                }
                public override bool IsReadOnly
                {
                    get { return innerProp.IsReadOnly; }
                }
            }
        }

        private void assetAddButton_Click(object sender, EventArgs e)
        {
            assetAdd nuAsset = new assetAdd(CustomerID);
            nuAsset.ShowDialog(this);
            bindClientAssets();
        }

        private void assetsGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                int assetID = (int)assetsGridView1.CurrentRow.Cells[0].Value;
            }
            catch (Exception x)
            {
                log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Error(x.Message);
            }
        }

        private void assetRuleAddButton_Click(object sender, EventArgs e)
        {
            //assetRulesdataGridView.AllowUserToAddRows = true;
        }




    }
}
