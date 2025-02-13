using Microsoft.Data.SqlClient;
using System.Data.SqlClient;



namespace E_commerceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtProductPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
                      // Check if product name is entered
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                return; // Do nothing if the text box is empty
            }

            
            string connectionString = "Data Source=A-SEWALAM\\SQLEXPRESS;Initial Catalog=E-commerceApp;Integrated Security=True;TrustServerCertificate=True"; // Replace with your actual connection string
           

            // Create the SqlConnection
            SqlConnection conn = new SqlConnection(connectionString);

            conn.Open(); // Open the connection

            string query = $"SELECT price, Image FROM PRODUCT WHERE productName ='{txtProductName.Text}'"; // Adjust table and column names as needed
            SqlCommand cmd = new SqlCommand(query, conn);
            

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read()) // If the product exists in the database
            {
                txtProductPrice.Text = reader["price"].ToString(); // Set the price

                // Directly set the image in the PictureBox
                byte[] imageBytes = (byte[])reader["Image"];
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    pictureBox1.Image = Image.FromStream(ms); // Display image in PictureBox
                }
            }
            else
            {
                MessageBox.Show("Out of stock", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning); // Product not found
                txtProductPrice.Clear(); // Clear the price textbox
                pictureBox1.Image = null; // Clear the picture box
            }

            reader.Close(); // Close the reader
            conn.Close(); // Close the connection
            conn.Dispose(); // Dispose of the connection
      
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtAcc_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string status = "Not Delivered";
            DateTime currentDate = DateTime.Now;

            // Connection string
            string connectionString = "Data Source=A-SEWALAM\\SQLEXPRESS;Initial Catalog=E-commerceApp;Integrated Security=True;TrustServerCertificate=True";

            string query = $"INSERT INTO ORDERS (orderPrice, status, CID, date) VALUES ('{txtProductPrice.Text}', '{status}', '{txtAcc.Text}', '{currentDate}')";

            // Declare SQL objects
            SqlConnection conn = new SqlConnection(connectionString);
          
            // Open the connection
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            // Execute the command
            int rowsAffected = cmd.ExecuteNonQuery();

            // Check the result and notify the user
            if (rowsAffected > 0)
            {
                MessageBox.Show("Order added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to add the order. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Clean up resources
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
 



    }
}

