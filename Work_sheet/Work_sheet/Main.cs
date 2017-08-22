using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Work_sheet
{
    public partial class Main : Form
    {
        public string ConnectionString { get; private set; }
        public List<Job> Jobs { get; private set; }

        public Table_Id All_Ids { get; private set; }

        public List<int> ListOfIds { get; private set; }

        public Main()
        {
            InitializeComponent();
            dataGridView1.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;
            Jobs = new List<Job>();
            newEntryToolStripMenuItem.Enabled = false;
            editSelectedToolStripMenuItem.Enabled = false;
            deleteSelectedToolStripMenuItem.Enabled = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void oPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog filePlace = new OpenFileDialog();
            filePlace.Title = "Browse for your file";
            filePlace.InitialDirectory = @"C:\";
            filePlace.Filter = "Data Base file (.db)|*.db";
            filePlace.RestoreDirectory = true;
            if (filePlace.ShowDialog() == DialogResult.OK)
            {
                ConnectionString = "Data Source=" + filePlace.FileName + ";Version=3;";
                dataGridView1.Rows.Clear();
                using (var con = new SQLiteConnection(ConnectionString))
                {
                    con.Open();

                    if (con.State == ConnectionState.Open)
                    {
                        newEntryToolStripMenuItem.Enabled = true;

                        if (ListOfIds != null) { ListOfIds.Clear(); }
                        ListOfIds = new List<int>();
                        var sql = "select * from times";
                        var cmd = new SQLiteCommand(sql, con);

                        var sql2 = "select count(*) from times";
                        var cmd2 = new SQLiteCommand(sql2, con);

                        var res = Convert.ToInt16(cmd2.ExecuteScalar());
                        if (res == 0)
                        {
                            con.Close();
                        }
                        else
                        {
                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                var id = Convert.ToInt16(reader["Id"]);
                                var started = Convert.ToDateTime(reader["Started"].ToString());
                                var finished = Convert.ToDateTime(reader["Started"].ToString());
                                var total = reader["Total"].ToString();
                                var assigned_by = reader["Assigned_by"].ToString();
                                var comment = reader["Comment"].ToString();

                                var job = new Job(started, finished, total, assigned_by, comment);

                                ListOfIds.Add(id);

                                Jobs.Add(job);
                            }
                            int num = 0;
                            foreach (var job in Jobs)
                            {
                                DataGridViewRow row = new DataGridViewRow();

                                row.CreateCells(dataGridView1);
                                row.Cells[0].Value = ListOfIds[num].ToString();
                                row.Cells[1].Value = Jobs[num].Started.ToString("yyyy-MM-dd HH:mm:ss");
                                row.Cells[2].Value = Jobs[num].Finished.ToString("yyyy-MM-dd HH:mm:ss");
                                row.Cells[3].Value = Jobs[num].Total;
                                row.Cells[4].Value = Jobs[num].Assigned_by;
                                row.Cells[5].Value = Jobs[num].Comment;
                                num++;

                                dataGridView1.Rows.Add(row);
                            }
                            //dataGridView1.DataSource = Jobs;

                            con.Close();
                        }
                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        editSelectedToolStripMenuItem.Enabled = true;
                        deleteSelectedToolStripMenuItem.Enabled = true;
                    }


                }
            }
        }

        private void newEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var new_entry = new New_Entry())
            {
                new_entry.ShowDialog();

                if (new_entry.DialogResult == DialogResult.OK)
                {
                    Jobs.Add(new_entry.NewJob);

                    int index;
                    if (dataGridView1.Rows.Count == 0)
                    {
                        index = 1;
                    }
                    else
                    {
                        DataGridViewRow LastRow = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                        index = Convert.ToInt16(LastRow.Cells[0].Value) + 1;
                    }

                    ListOfIds.Add(index);

                    int num = Jobs.Count();
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = index.ToString();
                    row.Cells[1].Value = Jobs[num - 1].Started.ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells[2].Value = Jobs[num - 1].Finished.ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells[3].Value = Jobs[num - 1].Total;
                    row.Cells[4].Value = Jobs[num - 1].Assigned_by;
                    row.Cells[5].Value = Jobs[num - 1].Comment;

                    dataGridView1.Rows.Add(row);


                    using (var con = new SQLiteConnection(ConnectionString))
                    {
                        con.Open();

                        var sql = "INSERT INTO times(Started,Finished,Total,Assigned_by,Comment) VALUES('" + new_entry.NewJob.Started.ToString("yyyy-MM-dd HH:mm:ss")
                        + "','" + new_entry.NewJob.Finished.ToString("yyyy-MM-dd HH:mm:ss") + "','" + new_entry.NewJob.Total + "','" + new_entry.NewJob.Assigned_by + "','" + new_entry.NewJob.Comment + "')";


                        var cmd = new SQLiteCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                    if (dataGridView1.Rows.Count > 0)
                    {
                        editSelectedToolStripMenuItem.Enabled = true;
                        deleteSelectedToolStripMenuItem.Enabled = true;
                    }
                }
            }
        }

        private void editSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = dataGridView1.CurrentCell.RowIndex + 1;

            using (var new_entry = new New_Entry())
            {
                new_entry.FormText(Jobs[id - 1].Started.ToString("yyyy-MM-dd HH:mm:ss"),
                    Jobs[id - 1].Finished.ToString("yyyy-MM-dd HH:mm:ss"),
                    Jobs[id - 1].Assigned_by, Jobs[id - 1].Comment);

                new_entry.ShowDialog();

                if (new_entry.DialogResult == DialogResult.OK)
                {
                    Jobs[id - 1] = new_entry.NewJob;

                    DataGridViewRow row = dataGridView1.CurrentRow;

                    row.Cells[1].Value = Jobs[id - 1].Started.ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells[2].Value = Jobs[id - 1].Finished.ToString("yyyy-MM-dd HH:mm:ss");
                    row.Cells[3].Value = Jobs[id - 1].Total;
                    row.Cells[4].Value = Jobs[id - 1].Assigned_by;
                    row.Cells[5].Value = Jobs[id - 1].Comment;

                    using (var con = new SQLiteConnection(ConnectionString))
                    {
                        con.Open();

                        var sql = "UPDATE times SET Started='" + new_entry.NewJob.Started.ToString("yyyy-MM-dd HH:mm:ss") + "',Finished='" + new_entry.NewJob.Finished.ToString("yyyy-MM-dd HH:mm:ss") +
                            "',Total='" + new_entry.NewJob.Total + "',Assigned_by='" + new_entry.NewJob.Assigned_by + "',Comment='" + new_entry.NewJob.Comment + "' WHERE Id=" + ListOfIds[id - 1] + "";

                        var cmd = new SQLiteCommand(sql, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                    }
                }
            }
        }

        private void deleteSelectedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = dataGridView1.CurrentCell.RowIndex + 1;

            DialogResult delete = MessageBox.Show("Are you sure?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (delete == DialogResult.Yes)
            {
                Jobs.Remove(Jobs[id - 1]);

                DataGridViewRow row = dataGridView1.CurrentRow;
                dataGridView1.Rows.RemoveAt(id - 1);

                using (var con = new SQLiteConnection(ConnectionString))
                {
                    con.Open();

                    var sql = "DELETE FROM times WHERE Id=" + ListOfIds[id - 1] + "";

                    var cmd = new SQLiteCommand(sql, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                }
            }
        }
        private void dataGridView1_SelectionChanged_1(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            toolStripStatusLabel1.Text ="Total time take on a project:  " + row.Cells[3].Value.ToString();
        }
    }
}
