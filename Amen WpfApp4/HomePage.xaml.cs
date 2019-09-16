using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using Xceed.Words.NET;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using DataTable = System.Data.DataTable;
using System.Collections.Generic;
using System.Diagnostics;

namespace Amen_WpfApp4
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {




        public HomePage()
        {
            InitializeComponent();
        }
        public object txtPath { get; private set; }

        MySqlConnection conn = new MySqlConnection("server=localhost;user id=root;database=agendamanagment");


        private void UploadFileButton_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                // Set filter for file extension and default file extension 
                dlg.DefaultExt = ".doc";
                dlg.Filter = "Word documents|*.doc;*.docx";

                // Display OpenFileDialog by calling ShowDialog method 
                Nullable<bool> result = dlg.ShowDialog();





                // Get the selected file name and display in a TextBox 
                if (result == true)
                {

                    //string filename = dlg.FileName;
                    //string path = System.IO.Path.GetFullPath(filename);
                    //var document = DocX.Load(filename);
                    //string content = document.Text;

                    List<string> headingsList = new List<string>();
                    List<string> heading2List = new List<string>();
                    //string myhead = headingsList.ToString();
                    //headingsList.ToArray();

                    Microsoft.Office.Interop.Word.Application app = new
                    Microsoft.Office.Interop.Word.Application();

                    Document doc = app.Documents.Open(dlg.FileName);
                    app.Application.Visible = false;

                    foreach (Microsoft.Office.Interop.Word.Paragraph paragraph in doc.Paragraphs)
                    {
                        Microsoft.Office.Interop.Word.Style style = paragraph.get_Style() as Microsoft.Office.Interop.Word.Style;
                        string styleName = style.NameLocal;
                        string text = paragraph.Range.Text;

                        string agendaID = agenda_id_text.Text;
                        string path = System.IO.Path.GetFullPath(dlg.FileName);
                        string minuteName = System.IO.Path.GetFileNameWithoutExtension(path);




                        if (styleName == "Heading 1")
                        {

                            string heading1 = text.ToString() + "\n";
                            MessageBox.Show(heading1);
                            headingsList.Add(heading1);

                            headingsList.ToArray();

                            /* if (styleName == "Heading 2")
                             {

                                 string heading2 = text.ToString();
                                 MessageBox.Show(heading2);
                                 heading2List.Add(heading2);


                             }*/
                            foreach (string head in headingsList)
                            {


                                if (heading1.Contains("Student"))
                                {


                                    string studentQuery = $"INSERT INTO student_agenda(agenda_Id, Agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";
                                    MySqlCommand student_cmd = new MySqlCommand(studentQuery, conn);
                                    conn.Open();
                                    student_cmd.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("Uploaded successfully to Student");
                                }



                                if (heading1.Contains("Faculty"))
                                {

                                    string facultyQuery = $"INSERT INTO faculty_agenda(agenda_Id, agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";
                                    MySqlCommand faculty_cmd = new MySqlCommand(facultyQuery, conn);
                                    conn.Open();
                                    faculty_cmd.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("Uploaded to Faculty Case");
                                }



                                if (heading1.Contains("Approval of previous minute"))
                                {
                                    string approveQuery = $"INSERT INTO approve_agenda(agenda_Id, agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";
                                    MySqlCommand approve_cmd = new MySqlCommand(approveQuery, conn);
                                    conn.Open();
                                    approve_cmd.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("uploaded to approval");
                                }

                                if (heading1.Contains("Matters arising from previous minutes"))
                                {
                                    string reviewQuery = $"INSERT INTO review_agenda(agenda_Id, agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";
                                    MySqlCommand review_cmd = new MySqlCommand(reviewQuery, conn);
                                    conn.Open();
                                    review_cmd.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("uploadded to review");
                                }


                                if (heading1.Contains("Staff"))
                                {
                                    string staffQuery = $"INSERT INTO staff_agenda(agenda_Id, agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";
                                    MySqlCommand staff_cmd = new MySqlCommand(staffQuery, conn);
                                    conn.Open();
                                    staff_cmd.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("uploadded to staff");
                                }


                                if (heading1.Contains("Other matters"))
                                {
                                    string othersQuery = $"INSERT INTO others_agenda(agenda_Id, agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";
                                    MySqlCommand other_cmd = new MySqlCommand(othersQuery, conn);
                                    conn.Open();
                                    other_cmd.ExecuteNonQuery();
                                    conn.Close();
                                    MessageBox.Show("uploadded to others");


                                }





                                /* string agendaQuery = $"INSERT INTO agenda(fagenda_id, Agenda_name, Data) VALUES ('{agendaID}','{minuteName}','{path}')";

                                  MySqlCommand agenda_cmd = new MySqlCommand(agendaQuery, conn);
                                  conn.Open();
                                  agenda_cmd.ExecuteNonQuery();
                                  conn.Close();
                                  MessageBox.Show("uploaded successfully in agenda");


                      */


                            }




                            //MessageBox.Show(myhead);
                        }
                    }





                    //foreach (string heading in headingsList)
                    //{
                    /*if (styleName == "Heading 2")
                    {
                        string heading2 = text.ToString();

                        //MessageBox.Show(heading2);


                    }*/
                }

            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally
            {
                conn.Close();
            }

        }


        private void ViewAgendas_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (comboBox.SelectedItem == this.studentCombo)
                {


                    string query = $"SELECT agenda_id, Agenda_name FROM student_agenda";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Close();
                    DataTable dts = new DataTable("student_agenda");
                    da.Fill(dts);
                    dataGrid1.ItemsSource = dts.DefaultView;

                    da.Update(dts);


                }




                else if (comboBox.SelectedItem == this.facultyCombo)
                {

                    string facultyquery = $"SELECT agenda_id, Agenda_name FROM faculty_agenda";
                    MySqlCommand facultycmd = new MySqlCommand(facultyquery, conn);
                    conn.Open();
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = facultycmd.ExecuteReader();
                    MySqlDataAdapter da = new MySqlDataAdapter(facultycmd);
                    conn.Close();
                    DataTable dtf = new DataTable("faculty_agenda");
                    da.Fill(dtf);

                    //dataGrid.ItemsControl.ItemsSource = dt.DefaultView; 

                    dataGrid1.ItemsSource = dtf.DefaultView;

                    //dataGrid.Children();
                    da.Update(dtf);



                }


                else if (comboBox.SelectedItem == this.staffCombo)
                {
                    string query = $"SELECT agenda_id, Agenda_name FROM staff_agenda";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Close();
                    DataTable dts = new DataTable("staff_agenda");
                    da.Fill(dts);
                    dataGrid1.ItemsSource = dts.DefaultView;

                    da.Update(dts);



                }

                else if (comboBox.SelectedItem == this.previousCombo)
                {
                    string query = $"SELECT agenda_id, Agenda_name FROM approve_agenda";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Close();
                    DataTable dts = new DataTable("approve_agenda");
                    da.Fill(dts);
                    dataGrid1.ItemsSource = dts.DefaultView;

                    da.Update(dts);

                }

                else if (comboBox.SelectedItem == this.othersCombo)


                {
                    string query = $"SELECT agenda_id, Agenda_name FROM others_agenda";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    conn.Open();
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    conn.Close();
                    DataTable dts = new DataTable("others_agenda");
                    da.Fill(dts);
                    dataGrid1.ItemsSource = dts.DefaultView;

                    da.Update(dts);


                }


            }




            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

    }
}