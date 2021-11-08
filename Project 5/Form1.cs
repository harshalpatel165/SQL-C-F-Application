using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Project_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static MySqlConnection conn;
        MySqlDataReader reader;
        static Microsoft.FSharp.Collections.FSharpList<HW5P2Lib.HW5P2.Article> alldata;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Title: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var x = inputBox.Text;
                var y = Convert.ToInt32(x);
                var output = HW5P2Lib.HW5P2.getTitle(y, alldata);
                textBox1.Text = header + output;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                string header = "Number of Words in The Article: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var x = inputBox.Text;
                var y = Convert.ToInt32(x);
                var output = HW5P2Lib.HW5P2.wordCount(y, alldata);
                textBox1.Text = header + output;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Month of Chosen Article: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var x = inputBox.Text;
                var y = Convert.ToInt32(x);
                var output = HW5P2Lib.HW5P2.getMonthName(y, alldata);
                textBox1.Text = header + output;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Unique Publishers: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var output = HW5P2Lib.HW5P2.publishers(alldata);
                string result = "";
                foreach (string line in output)
                {
                    result += line;
                    result += Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + result;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Unique Countries: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var output = HW5P2Lib.HW5P2.countries(alldata);
                string result = "";
                foreach (string line in output)
                {
                    result += line;
                    result += Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + result;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Average News Guard Score for All Articles: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var output = HW5P2Lib.HW5P2.avgNewsguardscoreForArticles(alldata);
                textBox1.Text = header + output;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Number of Articles for Each Month: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                Microsoft.FSharp.Collections.FSharpList<Tuple<string, int>> nArticles = HW5P2Lib.HW5P2.numberOfArticlesEachMonth(alldata);
                string output = HW5P2Lib.HW5P2.buildHistogram(nArticles, alldata.Length, "");
                string replacement = output.Replace("\n", Environment.NewLine);
                textBox1.Text = header + Environment.NewLine + replacement;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Percentage of Articles That Are Reliable for Each Publisher: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                Microsoft.FSharp.Collections.FSharpList<Tuple<string, double>> reliablepct = HW5P2Lib.HW5P2.reliableArticlePercentEachPublisher(alldata);
                Microsoft.FSharp.Collections.FSharpList<string> output = HW5P2Lib.HW5P2.printNamesAndPercentages(reliablepct);
                string result = "";
                foreach (string line in output)
                {
                    result += line;
                    result += Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + result;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "Average News Guard Score for Each Country: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var output = HW5P2Lib.HW5P2.avgNewsguardscoreEachCountry(alldata, "");
                Microsoft.FSharp.Collections.FSharpList<string> lines1 = HW5P2Lib.HW5P2.printNamesAndFloats(output);
                string result = "";
                foreach (string line in lines1)
                {
                    result += line;
                    result += Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + result;
            }
            catch
            {
                textBox1.Text = "error";
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                string header = "The Average News Guard Score for Each Political Bias Category: ";
                string filename = inputFileBox.Text;
                alldata = HW5P2Lib.HW5P2.readfile(filename);
                var output = HW5P2Lib.HW5P2.avgNewsguardscoreEachBias(alldata);
                string output2 = HW5P2Lib.HW5P2.buildHistogramFloat(output, "");
                string replacement = output2.Replace("\n", Environment.NewLine);
                textBox1.Text = header + Environment.NewLine + replacement;
            }
            catch
            {
                textBox1.Text = "error";
            }
        }

        private void connectionFunc()
        {
            try
            {
                string hostName = hostBox.Text;
                string portName = portBox.Text;
                string username = usernameBox.Text;
                string password = passwordBox.Text;
                string database = databaseBox.Text;
                string connStr = String.Format("server={0};user={1};database={2};port={3};password={4}", hostName, username, database, portName, password);  // change the database and password to test on your machine
                conn = new MySqlConnection(connStr);                                                     // must be these values when submitting to gradescope
                conn.Open();
            }
            catch (Exception ex)
            {
                textBox1.Text = "connection error";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            connectionFunc();
            var x = inputBox.Text;
            int nid = Convert.ToInt32(x);
            try
            {
                string query = String.Format(@" 
                                                SELECT title
                                                FROM news
                                                WHERE news_id = {0};
                                            ", nid);
                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t", reader.GetName(0));
                while (reader.Read())
                {
                    output += String.Format("{0}\t", reader.GetString(0)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT news_id, LENGTH(body_text) AS length
                                                FROM news
                                                WHERE LENGTH(body_text)>100
                                                ORDER BY news_id;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1}", reader.GetString(0), reader.GetString(1)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT title, DATE_FORMAT(STR_TO_DATE(publish_date, '%c/%d/%y'), '%M') AS Month
                                                FROM news
                                                ORDER BY STR_TO_DATE(publish_date, '%m/%d/%y')
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1}", reader.GetString(0), reader.GetString(1)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT publisher
                                                FROM publisher_table
                                                JOIN news
                                                USING (publisher_id)
                                                GROUP BY publisher
                                                ORDER BY publisher;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t", reader.GetName(0));
                while (reader.Read())
                {
                    output += String.Format("{0}\t", reader.GetString(0)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT country, COUNT(news_id) AS articleCount
                                                FROM country_table
                                                LEFT JOIN news
                                                USING (country_id)
                                                GROUP BY country
                                                ORDER BY articleCount DESC;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1}", reader.GetString(0), reader.GetInt32(1)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT ROUND(AVG(news_guard_score),3) AS `Average Score`
                                                FROM news;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t", reader.GetName(0));
                while (reader.Read())
                {
                    output += String.Format("{0:#0.000}\t", reader.GetFloat(0)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT month, numArticles, overall, ROUND(100*numArticles/overall,3) AS percentage
                                                FROM
                                                (
                                                SELECT month, monthnum, COUNT(publish_date) AS numArticles, overallCount AS overall
                                                FROM
                                                (
                                                SELECT DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%M') AS month, 
                                                       DATE_FORMAT(STR_TO_DATE(publish_date, '%m/%d/%y'), '%m') AS monthnum,
	                                                   publish_date
                                                FROM news
                                                ) AS T1
                                                JOIN
                                                (
                                                SELECT COUNT(*) overallCount FROM news
                                                ) AS T2
                                                GROUP BY month, monthnum, overallCount
                                                ) AS T3
                                                ORDER BY monthnum;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}\t{2}\t{3}", reader.GetName(0), reader.GetName(1), reader.GetName(2), reader.GetName(3));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1}\t{2}\t{3:#0.000}", reader.GetString(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetFloat(3)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT publisher, ROUND(AVG(reliability)*100, 3) AS percentage
                                                FROM news
                                                JOIN publisher_table
                                                USING (publisher_id)
                                                GROUP BY publisher
                                                ORDER BY percentage DESC, publisher;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1:#0.000}\t", reader.GetString(0), reader.GetFloat(1)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT country, ROUND(AVG(news_guard_score),3) AS avg_news_score
                                                FROM news
                                                JOIN country_table
                                                USING (country_id)
                                                GROUP BY country
                                                ORDER BY AVG(news_guard_score) DESC, country ASC;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}", reader.GetName(0), reader.GetName(1));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1:#0.000}\t", reader.GetString(0), reader.GetFloat(1)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            connectionFunc();
            try
            {
                string query = String.Format(@" 
                                                SELECT author, political_bias, COUNT(*) AS numArticles
                                                FROM news
                                                JOIN news_authors
                                                USING (news_id)
                                                JOIN author_table
                                                USING (author_id)
                                                JOIN political_bias_table
                                                USING (political_bias_id)
                                                GROUP BY author, political_bias
                                                ORDER BY author, COUNT(*) DESC, political_bias;
                                            ");

                MySqlCommand cmd = new MySqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                string output = "";
                string header = String.Format("{0}\t{1}\t{2}", reader.GetName(0), reader.GetName(1), reader.GetName(2));
                while (reader.Read())
                {
                    output += String.Format("{0}\t{1}\t{2}", reader.GetString(0), reader.GetString(1), reader.GetFloat(2)) + Environment.NewLine;
                }
                textBox1.Text = header + Environment.NewLine + output;
                reader.Close();
            }
            catch (Exception ex)
            {
                textBox1.Text = "error";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputFileBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void hostBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void portBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void databaseBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
