using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.IO;
using System.ComponentModel.Design;
using System.Windows.Documents;
using System.Security.Principal;
using System.Windows.Controls;
using GoodJOB.Home;
using System.Windows.Shapes;

namespace GoodJOB
{
    internal class ConnectSql
    {
        private string strCon = @"Data Source=TuF-Bin\SQLEXPRESS;Initial Catalog=GoodJOB;Integrated Security=True;Encrypt=False";
        private SqlConnection? sqlCon = null;

        private void Connect()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }

            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        private SqlCommand? ExcuAccount(string temp, Account account)
        {
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = temp;

            sqlCmd.Parameters.AddWithValue("@userName", account.UserName);
            sqlCmd.Parameters.AddWithValue("@pass", account.Pass);
            sqlCmd.Parameters.AddWithValue("@role", account.Role);
            sqlCmd.Parameters.AddWithValue("@accountID", account.AccountID);

            try
            {
                Connect();
                sqlCmd.Connection = sqlCon;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            return sqlCmd;

        }

        public bool ExcuLogin(ref Account account, string cmd, ref string infor)
        {
            SqlCommand? sqlCmd = ExcuAccount(cmd, account);
            try
            {
                SqlDataReader reader = sqlCmd!.ExecuteReader();
                while (reader.Read())
                {
                    string userName = reader.GetString(0);
                    string pass = reader.GetString(1);
                    string role = reader.GetString(2);
                    string accountID = reader.GetString(3);
                    if (userName == account.UserName && pass == account.Pass)
                    {
                        account.Role = role;
                        account.AccountID = accountID;
                        return true;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                infor = ex.Message;
            }
            finally { sqlCon!.Close(); }
            infor = "Tên đăng nhập hoặc mật khẩu không đúng !";
            return false;
        }

        public bool ExcuSignUp(Account account, string cmd)
        {
            SqlCommand? sqlCmd = ExcuAccount(cmd, account);
            try
            {
                int equal = sqlCmd!.ExecuteNonQuery();
                if (equal > 0)
                {
                    MessageBox.Show("Tạo tài khoản thành công !", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo tài khoản không thành công ! Mã lỗi: " + ex.Message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public bool AddCompany(string accountID)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert dbo.Company(AccountID) VALUES(@accountID)";

            sqlCmd.Parameters.AddWithValue("@accountID", accountID);

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool AddSeeker(string accountID)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "Insert dbo.Seeker(AccountID) VALUES(@accountID)";

            sqlCmd.Parameters.AddWithValue("@accountID", accountID);

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public string GetNameCompany(string id)
        {
            string result = "ahihi";
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT Name FROM dbo.Company WHERE AccountID = '" + id + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetString(0);
            }

            reader.Close();
            return result;
        }

        public string GetJobName(int id)
        {
            string result = "ahihi";
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT JobName FROM dbo.Post WHERE PostID = " + id;

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            if (reader.Read())
            {
                result = reader.GetString(0);
            }

            reader.Close();

            return result;
        }

        public bool DeletePost(int id)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM dbo.Post WHERE PostID = " + id.ToString();

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public List<EditPostUC> LoadEditJob(string account)
        {
            List<EditPostUC> list = new List<EditPostUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Post WHERE AccountID = '" + account + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string jobName = reader.GetString(0);
                string field = reader.GetString(1);
                string workingTime = reader.GetString(2);
                string typeOfWork = reader.GetString(3);
                string salary = reader.GetString(4);
                string exp = reader.GetString(5);
                string skill = reader.GetString(6);
                string description = reader.GetString(7);
                int numOfRecrui = reader.GetInt32(8);
                DateTime dateOfPost = reader.GetDateTime(9);
                string accountID = reader.GetString(10);
                int postID = reader.GetInt32(11);
                DateTime postingDate = reader.GetDateTime(12);
                string welfare = reader.GetString(13);

                JobPost jobPost = new JobPost(jobName, field, workingTime, typeOfWork, salary, exp, skill, description, numOfRecrui, dateOfPost, accountID, postID, postingDate, welfare);

                EditPostUC editPostUC = new EditPostUC(jobPost);

                list.Add(editPostUC);
            }
            reader.Close();

            return list;
        }

        public List<JobPostUC> LoadJobPost(ref HashSet<string> hsField, string seekerID)
        {
            hsField.Add("Lĩnh vực");
            List<JobPostUC> list = new List<JobPostUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT P.*, C.Name, '" + seekerID + "' as SeekerID FROM Post P JOIN dbo.Company C ON C.AccountID = P.AccountID " +
                        "WHERE NOT EXISTS (SELECT 1 FROM dbo.Recrui R WHERE R.PostID = P.PostID AND R.SeekerID = '" + seekerID + "')";


            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string jobName = reader.GetString(0);
                string field = reader.GetString(1);
                string workingTime = reader.GetString(2);
                string typeOfWork = reader.GetString(3);
                string salary = reader.GetString(4);
                string exp = reader.GetString(5);
                string skill = reader.GetString(6);
                string description = reader.GetString(7);
                int numOfRecrui = reader.GetInt32(8);
                DateTime dateOfPost = reader.GetDateTime(9);
                string accountID = reader.GetString(10);
                int postID = reader.GetInt32(11);
                DateTime postingDate = reader.GetDateTime(12);
                string welfare = reader.GetString(13);

                hsField.Add(field);

                JobPost jobPost = new JobPost(jobName, field, workingTime, typeOfWork, salary, exp, skill, description, numOfRecrui, dateOfPost, accountID, postID, postingDate, welfare);

                DateTime dt = DateTime.Now;
                int result = dt.CompareTo(jobPost.DateOfPost);
                if (result < 0)
                {
                    JobPostUC jobPostUC = new JobPostUC(jobPost);
                    list.Add(jobPostUC);
                }

                

            }
            reader.Close();

            return list;
        }

        public List<JobPostUC> SearchJob(string seekerID, string txbJobName, string cbbField, string cbbExp, string cbbSalary, string cbbTypeOfWork, string cbbLocation)
        {
            string temp = "";
            int count = 0;
            temp = "SELECT P.*, C.Name, '" + seekerID + "' as SeekerID FROM dbo.Post P JOIN dbo.Company C ON P.AccountID = C.AccountID ";

            if (txbJobName != "Nhập tên công việc")
            {
                temp += "WHERE P.JobName LIKE '%" + txbJobName + "%' ";
                count++;
            }

            if (cbbField != "Lĩnh vực")
            {
                count++;
                if (count == 1) temp += (count == 1 ? "WHERE" : "AND") + " P.Field = N'" + cbbField + "' ";
                else temp += "AND P.Field = N'" + cbbField + "' ";
            }

            if (cbbExp != "Kinh nghiệm")
            {
                count++;
                if (count == 1) temp += (count == 1 ? "WHERE" : "AND") + " P.Exp = N'" + cbbExp + "' ";
                else temp += "AND P.Exp = N'" + cbbExp + "' ";
            }

            if (cbbSalary != "Mức lương")
            {
                string salary = "";
                if (cbbSalary == "Theo tháng")
                {
                    salary = "%tháng%";
                }
                else if (cbbSalary == "Theo giờ")
                {
                    salary = "%giờ%";
                }
                else salary = "%/%' AND P.Salary NOT LIKE '%tháng%' AND P.Salary NOT LIKE '%giờ% ";

                count++;
                if (count == 1) temp += (count == 1 ? "WHERE" : "AND") + " P.Salary LIKE '" + salary + "' ";
                else temp += "AND P.Salary LIKE '" + salary + "' ";
            }

            if (cbbTypeOfWork != "Hình thức")
            {
                count++;
                if (count == 1) temp += (count == 1 ? "WHERE" : "AND") + " P.TypeOfWork = N'" + cbbTypeOfWork + "' ";
                else temp += "AND P.TypeOfWork = N'" + cbbTypeOfWork + "' ";
            }

            if (cbbLocation != "Chọn khu vực")
            {
                count++;
                if (count == 1) temp += (count == 1 ? "WHERE" : "AND") + " C.VPDD = N'" + cbbLocation + "' ";
                else temp += "AND C.VPDD = N'" + cbbLocation + "' ";
            }


            List<JobPostUC> list = new List<JobPostUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = temp + "AND NOT EXISTS (SELECT 1 FROM dbo.Recrui R WHERE R.PostID = P.PostID AND R.SeekerID = '" + seekerID + "')";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string jobName = reader.GetString(0);
                string field = reader.GetString(1);
                string workingTime = reader.GetString(2);
                string typeOfWork = reader.GetString(3);
                string salary = reader.GetString(4);
                string exp = reader.GetString(5);
                string skill = reader.GetString(6);
                string description = reader.GetString(7);
                int numOfRecrui = reader.GetInt32(8);
                DateTime dateOfPost = reader.GetDateTime(9);
                string accountID = reader.GetString(10);
                int postID = reader.GetInt32(11);
                DateTime postingDate = reader.GetDateTime(12);
                string welfare = reader.GetString(13);

                JobPost jobPost = new JobPost(jobName, field, workingTime, typeOfWork, salary, exp, skill, description, numOfRecrui, dateOfPost, accountID, postID, postingDate, welfare);

                JobPostUC jobPostUC = new JobPostUC(jobPost);
                list.Add(jobPostUC);

            }
            reader.Close();

            return list;

        }

        

        public bool Post(JobPost jobPost)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT dbo.Post VALUES (@jobName, @field, @workingTime, @typeOfWork, @salary, @exp, @skill, @description, @numOfRecrui, @dateOfPost, @accountID, @postingDate, @welfare)";

            sqlCmd.Parameters.AddWithValue("@jobName", jobPost.JobName);
            sqlCmd.Parameters.AddWithValue("@field", jobPost.Field);
            sqlCmd.Parameters.AddWithValue("@workingTime", jobPost.WorkingTime);
            sqlCmd.Parameters.AddWithValue("@typeOfWork", jobPost.TypeOfWork);
            sqlCmd.Parameters.AddWithValue("@salary", jobPost.Salary);
            sqlCmd.Parameters.AddWithValue("@exp", jobPost.Exp);
            sqlCmd.Parameters.AddWithValue("@skill", jobPost.Skill);
            sqlCmd.Parameters.AddWithValue("@description", jobPost.Description);
            sqlCmd.Parameters.AddWithValue("@numOfRecrui", jobPost.NumOfRecrui);
            sqlCmd.Parameters.AddWithValue("@dateOfPost", jobPost.DateOfPost);
            sqlCmd.Parameters.AddWithValue("@accountID", jobPost.AccountID);
            sqlCmd.Parameters.AddWithValue("@postingDate", jobPost.PostingDate);
            sqlCmd.Parameters.AddWithValue("@welfare", jobPost.Welfare);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditPost(JobPost jobPost)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Post SET JobName = @jobName, Field = @field, WorkingTime = @workingTime, TypeOfWork = @typeOfWork, Salary = @salary, Exp = @exp, Skill = @skill, Description = @description, NumOfRecrui = @numOfRecrui, DateOfPost = @dateOfPost, PostingDate = @postingDate, Welfare = @welfare WHERE AccountID = @accountID AND PostID = " + jobPost.PostID.ToString();

            sqlCmd.Parameters.AddWithValue("@jobName", jobPost.JobName);
            sqlCmd.Parameters.AddWithValue("@field", jobPost.Field);
            sqlCmd.Parameters.AddWithValue("@workingTime", jobPost.WorkingTime);
            sqlCmd.Parameters.AddWithValue("@typeOfWork", jobPost.TypeOfWork);
            sqlCmd.Parameters.AddWithValue("@salary", jobPost.Salary);
            sqlCmd.Parameters.AddWithValue("@exp", jobPost.Exp);
            sqlCmd.Parameters.AddWithValue("@skill", jobPost.Skill);
            sqlCmd.Parameters.AddWithValue("@description", jobPost.Description);
            sqlCmd.Parameters.AddWithValue("@numOfRecrui", jobPost.NumOfRecrui);
            sqlCmd.Parameters.AddWithValue("@dateOfPost", jobPost.DateOfPost);
            sqlCmd.Parameters.AddWithValue("@accountID", jobPost.AccountID);
            sqlCmd.Parameters.AddWithValue("@postingDate", jobPost.PostingDate);
            sqlCmd.Parameters.AddWithValue("@welfare", jobPost.Welfare);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool ApplyJob(int postID, string companyID, string seekerID, string filePath, byte[] fileBytes)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT dbo.Recrui VALUES (@postID, @companyID, @seekerID, @fileName, @fileContent, NULL)";

            sqlCmd.Parameters.AddWithValue("@postID", postID);
            sqlCmd.Parameters.AddWithValue("@companyID", companyID);
            sqlCmd.Parameters.AddWithValue("@seekerID", seekerID);
            sqlCmd.Parameters.AddWithValue("@fileName", System.IO.Path.GetFileName(filePath));
            sqlCmd.Parameters.AddWithValue("@fileContent", fileBytes);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public byte[]? DownLoadCV(int postID, string seekerID)
        {
            byte[]? fileContent = null;

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT FileContent FROM dbo.Recrui WHERE PostID = @postID AND SeekerID = @seekerID";

            sqlCmd.Parameters.AddWithValue("@postID", postID);
            sqlCmd.Parameters.AddWithValue("@seekerID", seekerID);

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                fileContent = (byte[])reader["FileContent"];
            }

            reader.Close();

            return fileContent;
        }

        public Company? GetInforCompany(string accountID)
        {
            Company? company = new Company();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Company WHERE AccountID = '" + accountID + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                company.AccountID = reader.GetString(0);
                if (!reader.IsDBNull(1))
                {
                    company.Name = reader.GetString(1);
                }
                else company.Name = "";
                if (!reader.IsDBNull(2))
                {
                    company.Phone = reader.GetString(2);
                }
                else company.Phone = "";
                if (!reader.IsDBNull(3))
                {
                    company.Address = reader.GetString(3);
                }
                else company.Address = "";
                if (!reader.IsDBNull(4))
                {
                    company.Email = reader.GetString(4);
                }
                else company.Email = "";
                if (!reader.IsDBNull(5))
                {
                    company.Vpdd = reader.GetString(5);
                }
                else company.Vpdd = "";
                if (!reader.IsDBNull(6))
                {
                    company.CeoName = reader.GetString(6);
                }
                else company.CeoName = "";
                if (!reader.IsDBNull(7))
                {
                    company.GpkdName = reader.GetString(7);
                }
                else company.GpkdName = null;
                if (!reader.IsDBNull(8))
                {
                    company.GpkdContent = (byte[])reader.GetValue(8);
                }
                else company.GpkdContent = null;
                if (!reader.IsDBNull(9))
                {
                    company.VatID = reader.GetString(9);
                }
                else company.VatID = "";
                if (!reader.IsDBNull(10))
                {
                    company.Introduce = reader.GetString(10);
                }
                else company.Introduce = "";
                if (!reader.IsDBNull(11))
                {
                    company.AvtName = reader.GetString(11);
                }
                else company.AvtName = "";
                if (!reader.IsDBNull(12))
                {
                    company.AvtContent = (byte[])reader.GetValue(12);
                }
                else company.AvtContent = null;
                if (!reader.IsDBNull(13))
                {
                    company.Like = reader.GetInt32(13);
                }
                else
                {
                    company.Like = 0;
                }
                
            }
            else company = null;
            reader.Close();
            return company;
        }

        public bool EditInforNonPicCompany(Company company)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Company SET Name = @name, Phone = @phone, Address = @address, Email = @email, VPDD = @vpdd, CEOName = @ceoName, VATID = @vatID, Introduce = @introduce WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", company.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", company.Name);
            sqlCmd.Parameters.AddWithValue("@phone", company.Phone);
            sqlCmd.Parameters.AddWithValue("@address", company.Address);
            sqlCmd.Parameters.AddWithValue("@email", company.Email);
            sqlCmd.Parameters.AddWithValue("@vpdd", company.Vpdd);
            sqlCmd.Parameters.AddWithValue("@ceoName", company.CeoName);
            sqlCmd.Parameters.AddWithValue("@vatID", company.VatID);
            sqlCmd.Parameters.AddWithValue("@introduce", company.Introduce);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditInforAvtCompany(Company company)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Company SET Name = @name, Phone = @phone, Address = @address, Email = @email, VPDD = @vpdd, CEOName = @ceoName, VATID = @vatID, Introduce = @introduce, AvtName = @avtName, AvtContent = @avtContent WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", company.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", company.Name);
            sqlCmd.Parameters.AddWithValue("@phone", company.Phone);
            sqlCmd.Parameters.AddWithValue("@address", company.Address);
            sqlCmd.Parameters.AddWithValue("@email", company.Email);
            sqlCmd.Parameters.AddWithValue("@vpdd", company.Vpdd);
            sqlCmd.Parameters.AddWithValue("@ceoName", company.CeoName);
            sqlCmd.Parameters.AddWithValue("@vatID", company.VatID);
            sqlCmd.Parameters.AddWithValue("@introduce", company.Introduce);
            sqlCmd.Parameters.AddWithValue("@avtName", System.IO.Path.GetFileName(company.AvtName));
            sqlCmd.Parameters.AddWithValue("@avtContent", company.AvtContent);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditInforGPKDCompany(Company company)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Company SET Name = @name, Phone = @phone, Address = @address, Email = @email, VPDD = @vpdd, CEOName = @ceoName, GPKDName = @gpkdName, GPKDContent = @gpkdContent, VATID = @vatID, Introduce = @introduce WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", company.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", company.Name);
            sqlCmd.Parameters.AddWithValue("@phone", company.Phone);
            sqlCmd.Parameters.AddWithValue("@address", company.Address);
            sqlCmd.Parameters.AddWithValue("@email", company.Email);
            sqlCmd.Parameters.AddWithValue("@vpdd", company.Vpdd);
            sqlCmd.Parameters.AddWithValue("@ceoName", company.CeoName);
            sqlCmd.Parameters.AddWithValue("@gpkdName", System.IO.Path.GetFileName(company.GpkdName));
            sqlCmd.Parameters.AddWithValue("@gpkdContent", company.GpkdContent);
            sqlCmd.Parameters.AddWithValue("@vatID", company.VatID);
            sqlCmd.Parameters.AddWithValue("@introduce", company.Introduce);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditInforCompany(Company company)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Company SET Name = @name, Phone = @phone, Address = @address, Email = @email, VPDD = @vpdd, CEOName = @ceoName, GPKDName = @gpkdName, GPKDContent = @gpkdContent, VATID = @vatID, Introduce = @introduce, AvtName = @avtName, AvtContent = @avtContent WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", company.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", company.Name);
            sqlCmd.Parameters.AddWithValue("@phone", company.Phone);
            sqlCmd.Parameters.AddWithValue("@address", company.Address);
            sqlCmd.Parameters.AddWithValue("@email", company.Email);
            sqlCmd.Parameters.AddWithValue("@vpdd", company.Vpdd);
            sqlCmd.Parameters.AddWithValue("@ceoName", company.CeoName);
            sqlCmd.Parameters.AddWithValue("@gpkdName", System.IO.Path.GetFileName(company.GpkdName));
            sqlCmd.Parameters.AddWithValue("@gpkdContent", company.GpkdContent);
            sqlCmd.Parameters.AddWithValue("@vatID", company.VatID);
            sqlCmd.Parameters.AddWithValue("@introduce", company.Introduce);
            sqlCmd.Parameters.AddWithValue("@avtName", System.IO.Path.GetFileName(company.AvtName));
            sqlCmd.Parameters.AddWithValue("@avtContent", company.AvtContent);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public byte[]? DownloadAvtCompany(string accountID)
        {
            byte[]? fileContent = null;

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT AvtContent FROM dbo.Company WHERE AccountID = '" + accountID + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                fileContent = (byte[])reader["AvtContent"];
            }

            reader.Close();

            return fileContent;
        }

        public byte[]? DownloadGPKD(string accountID)
        {
            byte[]? fileContent = null;

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT GPKDContent FROM dbo.Company WHERE AccountID = '" + accountID + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                fileContent = (byte[])reader["GPKDContent"];
            }

            reader.Close();

            return fileContent;
        }

        public Seeker? GetInforSeeker(string accountID)
        {
            Seeker? seeker = new Seeker();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Seeker WHERE AccountID = '" + accountID + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                seeker.AccountID = reader.GetString(0);
                if (!reader.IsDBNull(1))
                {
                    seeker.Name = reader.GetString(1);
                }
                else seeker.Name = "";
                if (!reader.IsDBNull(2))
                {
                    seeker.Phone = reader.GetString(2);
                }
                else seeker.Phone = "";
                if (!reader.IsDBNull(3))
                {
                    seeker.Email = reader.GetString(3);
                }
                else seeker.Email = "";
                if (!reader.IsDBNull(4))
                {
                    seeker.Sex = reader.GetBoolean(4);
                }
                else seeker.Sex = true;
                if (!reader.IsDBNull(5))
                {
                    seeker.Major = reader.GetString(5);
                }
                else seeker.Major = "";
                if (!reader.IsDBNull(6))
                {
                    seeker.LanguageDegree = reader.GetString(6);
                }
                else seeker.LanguageDegree = "";
                if (!reader.IsDBNull(7))
                {
                    seeker.Birthday = reader.GetString(7);
                }
                else seeker.Birthday = "";
                if (!reader.IsDBNull(8))
                {
                    seeker.AvtName = reader.GetString(8);
                }
                else seeker.AvtName = "";
                if (!reader.IsDBNull(9))
                {
                    seeker.AvtContent = (byte[])reader.GetValue(9);
                }
                else seeker.AvtContent = null;
                if (!reader.IsDBNull(10))
                {
                    seeker.Like = reader.GetInt32(10);
                }
                else
                {
                    seeker.Like = 0;
                }
                if (!reader.IsDBNull(11))
                {
                    seeker.CvPath = reader.GetString(11);
                }
                else seeker.CvPath = "";
                if (!reader.IsDBNull(12))
                {
                    seeker.CvBytes = (byte[])reader.GetValue(12);
                }
                else seeker.CvBytes = null;
            }
            else seeker = null;
            reader.Close();
            return seeker;
        }

        public bool EditInforNonPicSeeker(Seeker seeker)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Seeker SET Name = @name, Phone = @phone, Email = @email, Sex = @sex, Major = @major, LanguageDegree = @languageDegree, Birthday = @birthday WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", seeker.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", seeker.Name);
            sqlCmd.Parameters.AddWithValue("@phone", seeker.Phone);
            sqlCmd.Parameters.AddWithValue("@Sex", seeker.Sex);
            sqlCmd.Parameters.AddWithValue("@email", seeker.Email);
            sqlCmd.Parameters.AddWithValue("@major", seeker.Major);
            sqlCmd.Parameters.AddWithValue("@languageDegree", seeker.LanguageDegree);
            sqlCmd.Parameters.AddWithValue("@birthday", seeker.Birthday);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditInforAvtSeeker(Seeker seeker)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Seeker SET Name = @name, Phone = @phone, Email = @email, Sex = @sex, Major = @major, LanguageDegree = @languageDegree, Birthday = @birthday, AvtName = @avtName, AvtContent = @avtContent WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", seeker.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", seeker.Name);
            sqlCmd.Parameters.AddWithValue("@phone", seeker.Phone);
            sqlCmd.Parameters.AddWithValue("@Sex", seeker.Sex);
            sqlCmd.Parameters.AddWithValue("@email", seeker.Email);
            sqlCmd.Parameters.AddWithValue("@major", seeker.Major);
            sqlCmd.Parameters.AddWithValue("@languageDegree", seeker.LanguageDegree);
            sqlCmd.Parameters.AddWithValue("@birthday", seeker.Birthday);
            sqlCmd.Parameters.AddWithValue("@avtName", System.IO.Path.GetFileName(seeker.AvtName));
            sqlCmd.Parameters.AddWithValue("@avtContent", seeker.AvtContent);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditInforCVSeeker(Seeker seeker)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Seeker SET Name = @name, Phone = @phone, Email = @email, Sex = @sex, Major = @major, LanguageDegree = @languageDegree, Birthday = @birthday, CvName = @cvName, CvContent = @cvContent WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", seeker.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", seeker.Name);
            sqlCmd.Parameters.AddWithValue("@phone", seeker.Phone);
            sqlCmd.Parameters.AddWithValue("@Sex", seeker.Sex);
            sqlCmd.Parameters.AddWithValue("@email", seeker.Email);
            sqlCmd.Parameters.AddWithValue("@major", seeker.Major);
            sqlCmd.Parameters.AddWithValue("@languageDegree", seeker.LanguageDegree);
            sqlCmd.Parameters.AddWithValue("@birthday", seeker.Birthday);
            sqlCmd.Parameters.AddWithValue("@cvName", System.IO.Path.GetFileName(seeker.CvPath));
            sqlCmd.Parameters.AddWithValue("@cvContent", seeker.CvBytes);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditInforSeeker(Seeker seeker)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Seeker SET Name = @name, Phone = @phone, Email = @email, Sex = @sex, Major = @major, LanguageDegree = @languageDegree, Birthday = @birthday, CvName = @cvName, CvContent = @cvContent, AvtName = @avtName, AvtContent = @avtContent WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", seeker.AccountID);
            sqlCmd.Parameters.AddWithValue("@name", seeker.Name);
            sqlCmd.Parameters.AddWithValue("@phone", seeker.Phone);
            sqlCmd.Parameters.AddWithValue("@Sex", seeker.Sex);
            sqlCmd.Parameters.AddWithValue("@email", seeker.Email);
            sqlCmd.Parameters.AddWithValue("@major", seeker.Major);
            sqlCmd.Parameters.AddWithValue("@languageDegree", seeker.LanguageDegree);
            sqlCmd.Parameters.AddWithValue("@birthday", seeker.Birthday);
            sqlCmd.Parameters.AddWithValue("@cvName", System.IO.Path.GetFileName(seeker.CvPath));
            sqlCmd.Parameters.AddWithValue("@cvContent", seeker.CvBytes);
            sqlCmd.Parameters.AddWithValue("@avtName", System.IO.Path.GetFileName(seeker.AvtName));
            sqlCmd.Parameters.AddWithValue("@avtContent", seeker.AvtContent);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public byte[]? DownloadCVSeeker(string accountID)
        {
            byte[]? fileContent = null;

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT CvContent FROM dbo.Seeker WHERE AccountID = '" + accountID + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                fileContent = (byte[])reader["CvContent"];
            }

            reader.Close();

            return fileContent;
        }

        public byte[]? DownloadAvtSeeker(string accountID)
        {
            byte[]? fileContent = null;

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT AvtContent FROM dbo.Seeker WHERE AccountID = '" + accountID + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                fileContent = (byte[])reader["AvtContent"];
            }

            reader.Close();

            return fileContent;
        }

        public bool LikeSeeker(string id, int like)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Seeker SET [Like] = @like WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", id);
            sqlCmd.Parameters.AddWithValue("@like", like);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool LikeCompany(string id, int like)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Company SET [Like] = @like WHERE AccountID = @accountID";

            sqlCmd.Parameters.AddWithValue("@accountID", id);
            sqlCmd.Parameters.AddWithValue("@like", like);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public JobPost GetPost(int postID)
        {
            JobPost post = new JobPost();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Post WHERE PostID = " + postID.ToString();

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                post.JobName = reader.GetString(0);
                post.Field = reader.GetString(1);
                post.WorkingTime = reader.GetString(2);
                post.TypeOfWork = reader.GetString(3);
                post.Salary = reader.GetString(4);
                post.Exp = reader.GetString(5);
                post.Skill = reader.GetString(6);
                post.Description = reader.GetString(7);
                post.NumOfRecrui = reader.GetInt32(8);
                post.DateOfPost = reader.GetDateTime(9);
                post.AccountID = reader.GetString(10);
                post.PostID = reader.GetInt32(11);
                post.PostingDate = reader.GetDateTime(12);
            }
            reader.Close();
            return post;
        }

        public List<RecruiUC> LoadJobPostRecrui(string id)
        {
            List<RecruiUC> list = new List<RecruiUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT PostID, CompanyID, Count(*) As Count FROM dbo.Recrui WHERE CompanyID = '" + id + "' AND Result IS NULL GROUP BY PostID, CompanyID";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int postID = reader.GetInt32(0);
                string companyID = reader.GetString(1);
                int count = reader.GetInt32(2);

                JobPostRecrui jobPostRecrui = new JobPostRecrui(postID, companyID, count);

                RecruiUC recruiUC = new RecruiUC(jobPostRecrui);

                list.Add(recruiUC);

            }
            reader.Close();

            return list;
        }

        public List<ResumeApplyUC> LoadRecrui(int id)
        {
            List<ResumeApplyUC> list = new List<ResumeApplyUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT R.* FROM dbo.Recrui R " +
                     "JOIN dbo.Seeker S ON R.SeekerID = S.AccountID " +
                     "WHERE R.PostID = '" + id.ToString() + "' AND R.Result IS NULL " +
                     "ORDER BY S.[Like] DESC";



            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int postID = reader.GetInt32(0);
                string companyID = reader.GetString(1);
                string seekerID = reader.GetString(2);
                string fileName = reader.GetString(3);
                byte[] fileContent = (byte[])reader.GetValue(4);
                bool? result = null;

                Recrui recrui = new Recrui(postID, companyID, seekerID, fileName, fileContent, result);

                ResumeApplyUC resumeApplyUC = new ResumeApplyUC(recrui);

                list.Add(resumeApplyUC);

            }
            reader.Close();

            return list;
        }

        public bool Interview(Recrui recrui, string result, DateTime dt, string address)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT dbo.Interview VALUES(@interviewDay, @address, @postID, @seekerID)";

            sqlCmd.Parameters.AddWithValue("interviewDay", dt);
            sqlCmd.Parameters.AddWithValue("address", address);
            sqlCmd.Parameters.AddWithValue("postID", recrui.PostID);
            sqlCmd.Parameters.AddWithValue("seekerID", recrui.SeekerID);

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0)
                    if (Reply(recrui, result)) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public Interview? GetInterview(Recrui recrui)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Interview WHERE PostID = @postID AND SeekerID = @seekerID";

            sqlCmd.Parameters.AddWithValue("@postID", recrui.PostID);
            sqlCmd.Parameters.AddWithValue("@seekerID", recrui.SeekerID);

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            if (reader.Read())
            {
                DateTime interviewDay = reader.GetDateTime(0);
                string address = reader.GetString(1);
                int postID = reader.GetInt32(2);
                string seekerID = reader.GetString(3);

                Interview interview = new Interview(interviewDay, address, postID, seekerID);
                reader.Close();
                return interview;
            }
            return null;
        }

        public bool Reply(Recrui recrui, string result)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.Recrui SET Result = " + result + " WHERE PostID = @postID AND SeekerID = @seekerID";

            sqlCmd.Parameters.AddWithValue("@postID", recrui.PostID);
            sqlCmd.Parameters.AddWithValue("@seekerID", recrui.SeekerID);

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public List<ExpUC> LoadExp(string id, SeekerInforUC us)
        {
            List<ExpUC> list = new List<ExpUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.WorkExp WHERE AccountID = '" + id + "'";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string accountID = reader.GetString(0);
                string jobName = reader.GetString(1);
                string workTime = reader.GetString(2);
                string companyName = reader.GetString(3);
                string description = reader.GetString(4);

                Exp exp = new Exp(accountID, jobName, workTime, companyName, description);

                ExpUC expUC = new ExpUC(exp, us);

                list.Add(expUC);

            }
            reader.Close();

            return list;
        }

        public bool MinusExp(Exp exp)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "DELETE FROM dbo.WorkExp WHERE AccountID = @accountID AND JobName = @jobName AND CompanyName = @companyName";

            sqlCmd.Parameters.AddWithValue("@accountID", exp.AccountID);
            sqlCmd.Parameters.AddWithValue("@jobName", exp.JobName);
            sqlCmd.Parameters.AddWithValue("@companyName", exp.CompanyName);

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool AddExp(Exp exp)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT dbo.WorkExp VALUES(@accountID, @jobName, @workTime, @companyName, @description)";

            sqlCmd.Parameters.AddWithValue("@accountID", exp.AccountID);
            sqlCmd.Parameters.AddWithValue("@jobName", exp.JobName);
            sqlCmd.Parameters.AddWithValue("@workTime", exp.WorkTime);
            sqlCmd.Parameters.AddWithValue("@companyName", exp.CompanyName);
            sqlCmd.Parameters.AddWithValue("@description", exp.Description);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public bool EditExp(Exp exp, string tempJobName, string tempCompanyName, string tempWorkTime, string tempDescription)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "UPDATE dbo.WorkExp SET AccountID = @accountID, JobName = @jobName, WorkTime = @workTime, CompanyName = @companyName, Description = @description WHERE JobName = @tempJobName AND WorkTime = @tempWorkTime AND CompanyName = @tempCompanyName AND Description = @tempDescription";

            sqlCmd.Parameters.AddWithValue("@accountID", exp.AccountID);
            sqlCmd.Parameters.AddWithValue("@jobName", exp.JobName);
            sqlCmd.Parameters.AddWithValue("@workTime", exp.WorkTime);
            sqlCmd.Parameters.AddWithValue("@companyName", exp.CompanyName);
            sqlCmd.Parameters.AddWithValue("@description", exp.Description);

            sqlCmd.Parameters.AddWithValue("@tempJobName", tempJobName);
            sqlCmd.Parameters.AddWithValue("@tempWorkTime", tempWorkTime);
            sqlCmd.Parameters.AddWithValue("@tempCompanyName", tempCompanyName);
            sqlCmd.Parameters.AddWithValue("@tempDescription", tempDescription);


            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public List<ManageRecruiUC> LoadManegeRecrui(Account account)
        {
            List<ManageRecruiUC> list = new List<ManageRecruiUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Recrui WHERE SeekerID = @seekerID AND Result IS NOT NULL";

            sqlCmd.Parameters.AddWithValue("@seekerID", account.AccountID);

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int postID = reader.GetInt32(0);
                string companyID = reader.GetString(1);
                string seekerID = reader.GetString(2);
                string fileName = reader.GetString(3);
                byte[] fileContent = (byte[])reader.GetValue(4);
                bool? result = reader.GetBoolean(5);

                Recrui recruiNew = new Recrui(postID, companyID, seekerID, fileName, fileContent, result);

                ManageRecruiUC manageRecruiUC = new ManageRecruiUC(recruiNew);

                list.Add(manageRecruiUC);

            }
            reader.Close();

            return list;

        }

        public List<ManageRecruiUC> LoadManegeRecruiNon(Account account)
        {
            List<ManageRecruiUC> list = new List<ManageRecruiUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Recrui WHERE SeekerID = @seekerID AND Result IS NULL";

            sqlCmd.Parameters.AddWithValue("@seekerID", account.AccountID);

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int postID = reader.GetInt32(0);
                string companyID = reader.GetString(1);
                string seekerID = reader.GetString(2);
                string fileName = reader.GetString(3);
                byte[] fileContent = (byte[])reader.GetValue(4);
                bool? result;
                if (!reader.IsDBNull(5))
                {
                    result = reader.GetBoolean(5);
                }
                else
                {
                    result = null;
                }

                Recrui recruiNew = new Recrui(postID, companyID, seekerID, fileName, fileContent, result);

                ManageRecruiUC manageRecruiUC = new ManageRecruiUC(recruiNew);

                list.Add(manageRecruiUC);

            }
            reader.Close();

            return list;

        }

        public bool SendMessage(string companyID, string seekerID, string role, string message, DateTime time)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT dbo.Message VALUES(@companyID, @seekerID, @role, @message, @time)";

            sqlCmd.Parameters.AddWithValue("@companyID", companyID);
            sqlCmd.Parameters.AddWithValue("@seekerID", seekerID);
            sqlCmd.Parameters.AddWithValue("@role", role);
            sqlCmd.Parameters.AddWithValue("@message", message);
            sqlCmd.Parameters.AddWithValue("@time", time);

            sqlCmd.Connection = sqlCon;

            try
            {
                if (sqlCmd.ExecuteNonQuery() > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }


        public List<Message> LoadMessage(string companyID, string seekerID)
        {
            List<Message> list = new List<Message>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Message WHERE CompanyID = @companyID AND SeekerID = @seekerID";

            sqlCmd.Parameters.AddWithValue("@companyID", companyID);
            sqlCmd.Parameters.AddWithValue("@seekerID", seekerID);

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                string company = reader.GetString(0);
                string seeker = reader.GetString(1);
                string role = reader.GetString(2);
                string mess = reader.GetString(3);
                DateTime time = reader.GetDateTime(4);

                Message message = new Message(company, seeker, role, mess, time);
                list.Add(message);

            }

            reader.Close();

            return list;
        }

        public List<ItemSeekerChatUC> LoadSeekerItemChat(string id)
        {
            List<ItemSeekerChatUC> list = new List<ItemSeekerChatUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM (" +
                     "    SELECT R.*, ROW_NUMBER() OVER(PARTITION BY R.SeekerID ORDER BY S.[Like] DESC) AS RowNum " +
                     "    FROM dbo.Recrui R " +
                     "    JOIN dbo.Seeker S ON R.SeekerID = S.AccountID " +
                     "    WHERE R.CompanyID = '" + id.ToString() + "'" +
                     ") AS SubQuery " +
                     "WHERE RowNum = 1";



            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int postID = reader.GetInt32(0);
                string companyID = reader.GetString(1);
                string seekerID = reader.GetString(2);
                string fileName = reader.GetString(3);
                byte[] fileContent = (byte[])reader.GetValue(4);
                bool? result = null;

                Recrui recrui = new Recrui(postID, companyID, seekerID, fileName, fileContent, result);

                ItemSeekerChatUC itemSeekerChatUC = new ItemSeekerChatUC(recrui);

                list.Add(itemSeekerChatUC);

            }
            reader.Close();

            return list;
        }

        public List<ItemCompanyChatUC> LoadCompanyItemChat(string id)
        {
            List<ItemCompanyChatUC> list = new List<ItemCompanyChatUC>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM (" +
                     "    SELECT R.*, ROW_NUMBER() OVER(PARTITION BY R.CompanyID ORDER BY P.[Like] DESC) AS RowNum " +
                     "    FROM dbo.Recrui R " +
                     "    JOIN dbo.Company P ON R.CompanyID = P.AccountID " +
                     "    WHERE R.SeekerID = '" + id.ToString() + "'" +
                     ") AS SubQuery " +
                     "WHERE RowNum = 1";



            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                int postID = reader.GetInt32(0);
                string companyID = reader.GetString(1);
                string seekerID = reader.GetString(2);
                string fileName = reader.GetString(3);
                byte[] fileContent = (byte[])reader.GetValue(4);
                bool? result = null;

                Recrui recrui = new Recrui(postID, companyID, seekerID, fileName, fileContent, result);

                ItemCompanyChatUC itemCompanyChatUC = new ItemCompanyChatUC(recrui);

                list.Add(itemCompanyChatUC);

            }
            reader.Close();

            return list;
        }

        public List<int> GetLikeCompnay()
        {
            List<int> list = new List<int>();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT [Like] FROM dbo.Company";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while(reader.Read())
            {
                int like = 0;
                if (!reader.IsDBNull(0))
                {
                    like = reader.GetInt32(0);
                }
                else like = 0;
                list.Add(like);
            }

            reader.Close();

            return list;
        }

        public List<string> LoadNameCompnay()
        {
            List<string> list = new List<string>();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT Name FROM dbo.Company";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string name = "";
                if (!reader.IsDBNull(0))
                {
                    name = reader.GetString(0);
                }
                else name = "";
                list.Add(name);
            }

            reader.Close();

            return list;
        }

        public List<Tuple<string, int>> LoadNumRecrui()
        {
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT AccountID, SUM(NumOfRecrui) FROM dbo.Post GROUP BY AccountID";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();

            while (reader.Read())
            {
                string name = reader.GetString(0);
                int num = reader.GetInt32(1);
                Tuple<string, int> tuple = new Tuple<string, int>(name, num);
                list.Add(tuple);

            }

            reader.Close();

            return list;
        }

        public List<TopSeekerUC> LoadTopSeeker(string role)
        {
            List<TopSeekerUC> list = new List<TopSeekerUC>();
            List<Seeker> topList = new List<Seeker>();
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType= CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.Seeker";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            while(reader.Read())
            {
                Seeker seeker = new Seeker();
                seeker.AccountID = reader.GetString(0);
                if (!reader.IsDBNull(1))
                {
                    seeker.Name = reader.GetString(1);
                }
                else seeker.Name = "";
                if (!reader.IsDBNull(2))
                {
                    seeker.Phone = reader.GetString(2);
                }
                else seeker.Phone = "";
                if (!reader.IsDBNull(3))
                {
                    seeker.Email = reader.GetString(3);
                }
                else seeker.Email = "";
                if (!reader.IsDBNull(4))
                {
                    seeker.Sex = reader.GetBoolean(4);
                }
                else seeker.Sex = true;
                if (!reader.IsDBNull(5))
                {
                    seeker.Major = reader.GetString(5);
                }
                else seeker.Major = "";
                if (!reader.IsDBNull(6))
                {
                    seeker.LanguageDegree = reader.GetString(6);
                }
                else seeker.LanguageDegree = "";
                if (!reader.IsDBNull(7))
                {
                    seeker.Birthday = reader.GetString(7);
                }
                else seeker.Birthday = "";
                if (!reader.IsDBNull(8))
                {
                    seeker.AvtName = reader.GetString(8);
                }
                else seeker.AvtName = "";
                if (!reader.IsDBNull(9))
                {
                    seeker.AvtContent = (byte[])reader.GetValue(9);
                }
                else seeker.AvtContent = null;
                if (!reader.IsDBNull(10))
                {
                    seeker.Like = reader.GetInt32(10);
                }
                else
                {
                    seeker.Like = 0;
                }
                if (!reader.IsDBNull(11))
                {
                    seeker.CvPath = reader.GetString(11);
                }
                else seeker.CvPath = "";
                if (!reader.IsDBNull(12))
                {
                    seeker.CvBytes = (byte[])reader.GetValue(12);
                }
                else seeker.CvBytes = null;

                if (seeker.Name != "") topList.Add(seeker);


            }
            reader.Close();

            topList.Sort((x, y) => y.Like.CompareTo(x.Like));

            for (int i =0; i< topList.Count; i++)
            {
                TopSeekerUC topSeekerUC = new TopSeekerUC(topList[i], i + 1, role);
                list.Add(topSeekerUC);
            }

            return list;
        }

        public bool GetPostSeeker(PostSeeker postSeeker)
        {
            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "INSERT dbo.PostSeeker VALUES(@job, @field, @time, @exp, @salary, @skill, @accountID)";

            sqlCmd.Parameters.AddWithValue("@job", postSeeker.Job);
            sqlCmd.Parameters.AddWithValue("@field", postSeeker.Field);
            sqlCmd.Parameters.AddWithValue("@time", postSeeker.Time);
            sqlCmd.Parameters.AddWithValue("@exp", postSeeker.Exp);
            sqlCmd.Parameters.AddWithValue("@salary", postSeeker.Salary);
            sqlCmd.Parameters.AddWithValue("@skill", postSeeker.Skill);
            sqlCmd.Parameters.AddWithValue("@accountID", postSeeker.AccountID);

            sqlCmd.Connection = sqlCon;

            try
            {
                int result = sqlCmd.ExecuteNonQuery();
                if (result > 0) return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return false;
        }

        public List<ItemPostSeerUC> LoadPostSeeker()
        {
            List<ItemPostSeerUC> list = new List<ItemPostSeerUC> ();

            Connect();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "SELECT * FROM dbo.PostSeeker";

            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();



            while (reader.Read())
            {
                 PostSeeker postSeeker = new PostSeeker();
                postSeeker.Job = reader.GetString(0);
                postSeeker.Field = reader.GetString(1);
                postSeeker.Time = reader.GetString(2);
                postSeeker.Exp = reader.GetString(3);
                postSeeker.Salary =    reader.GetString(4);
                postSeeker.Skill = reader.GetString(5);
                postSeeker.AccountID = reader.GetString(6);

                ItemPostSeerUC itemPostSeerUC = new ItemPostSeerUC(postSeeker);
                list.Add(itemPostSeerUC);

            }

            reader.Close();

            return list;
        }
    }
}
