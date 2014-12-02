using System;
using System.Linq;
using System.Text;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Threading;



namespace CompuTrackWPF
{
    class PDF_Output
    {

        //for print functions 
        public string name_box, type_box, accessories_box, make_box,
            model_box, descritp_box, adapter_brand_box, serial_box, defects_box, day_created,
            ticket_company, ticket_email, ticket_phone, ticket_password, ticket_cityStateZip,
            ticket_number_print, type_of_pc, eta_box, ticket_address;
        public Boolean? ac_adapter_box;
       
       

        public void write_stream(object sender, EventArgs e)
        {

            //Copy Method is messing up something will fix later....
            Copy_to_New_File();
            Fill_Fields();



        }

        protected String Get_User_Path_Dir()
        {
            String directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            directory = System.IO.Path.Combine(directory, "CompuTrack\\");
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);

            }

            return directory;

        }

        protected void Copy_to_New_File()
        {
            try
            {

                if (!File.Exists(Get_User_Path_Dir() + "ramPDF.pdf"))
                {
                    File.Copy("ramPDF.pdf", Get_User_Path_Dir() + "ramPDF.pdf");
                }
                if (!File.Exists(Get_User_Path_Dir() + "ramPDF_filled"))
                {
                    File.Copy("ramPDF_filled.pdf", Get_User_Path_Dir() + "ramPDF_filled.pdf");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }

        private string get_field_names(AcroFields fields)
        {
            //Note: This method is only needed if rebuilding the program and identification of new forms is needed!
            StringBuilder sb = new StringBuilder();

            foreach (string key in fields.Fields.Keys)
            {
                

                sb.Append(key + Environment.NewLine);

            }
            return sb.ToString();

        }

        protected void Fill_Fields()
        {
            String pdf_Original = (Get_User_Path_Dir() + "ramPDF.pdf");
            String new_PdfRam = (Get_User_Path_Dir() + "ramPDF_filled.pdf");
            PdfReader reader = new PdfReader(pdf_Original);

              while (check_for_Open_pdf(new_PdfRam) == true)
              {
                  System.Windows.MessageBox.Show("Please Close the opened PDF.");
              }

            PdfStamper stamper = new PdfStamper(reader, new FileStream(new_PdfRam, FileMode.Append));
            AcroFields pdfFormFields = stamper.AcroFields;
            BaseFont font = BaseFont.CreateFont("times.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
           
            stamper.AcroFields.AddSubstitutionFont(font);
            stamper.AcroFields.SubstitutionFonts.Add(font);

            Thread.Sleep(1500); 
            add_to_fields(pdfFormFields);
            
            //flatten the pdf so it is no longer editable
            stamper.FormFlattening = true;
            stamper.Close();

            Process.Start(Get_User_Path_Dir() + "ramPDF_filled.pdf");


        }

        public void setPrintSimple(String model, String type, String accessories, String make, String description,
            String adapter_brand, String serial, String defects, string eta, Boolean? ac_adapter, String type_View,
            String name, string ticket_number, String company, string email, string phone, String password_box, string address_box,
            String city_State_Zip, string current_day)
        {
            name_box = name;
            model_box = model;
            type_box = type;
            accessories_box = accessories;
            make_box = make;
            descritp_box = description;
            adapter_brand_box = adapter_brand;
            serial_box = serial;
            defects_box = defects;
            eta_box = eta;
            ac_adapter_box = ac_adapter;
            type_of_pc = type_View;
            ticket_number_print = ticket_number;
            day_created = current_day;
            ticket_company = company;
            ticket_email = email;
            ticket_phone = phone;
            ticket_password = password_box;
            ticket_address = address_box;
            ticket_cityStateZip = city_State_Zip;

        }

        protected void check_value_acAdapter(AcroFields pdf_Fields)
        {

            if (ac_adapter_box.Value == true)
            {
                pdf_Fields.SetField("adapterCheckBox", "Yes");
                pdf_Fields.SetField("adapterBrand", adapter_brand_box);
            }
            if (ac_adapter_box.Value == false)
            {
                return;

            }
        }

        protected void check_Type_of_Pc(AcroFields pdf_Fields)
        {
            if (type_of_pc == "Desktop" || type_of_pc == "desktop")
            {
                pdf_Fields.SetField("desktopCheckBox", "Yes");
            }
            else if (type_of_pc == "Laptop" || type_of_pc == "laptop")
            {
                pdf_Fields.SetField("laptopCheckBox", "Yes");
            }
            else if (type_of_pc == "NetBook" || type_of_pc == "netbook" || type_of_pc == "Netbook")
            {
                pdf_Fields.SetField("netbookCheckBox", "Yes");
            }
            else
            {
                pdf_Fields.SetField("other", type_of_pc);
            }
        }

        protected bool check_for_Open_pdf(string file_name)
        {
            FileStream stream = null;

            try
            {
                stream = System.IO.File.Open(file_name, FileMode.Append);
            }
            catch
            {
                //This will catch if the file is open.
                return true;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                    
                }
            }
            return false;
        }

        protected void add_to_fields(AcroFields pdfFormFields)
        {
            pdfFormFields.SetField("name", name_box);
            pdfFormFields.SetField("company", ticket_company);
            pdfFormFields.SetField("address", ticket_address);
            pdfFormFields.SetField("location", ticket_cityStateZip);
            pdfFormFields.SetField("ticketNo", ticket_number_print);
            pdfFormFields.SetField("dateReceived", day_created);
            pdfFormFields.SetField("eta", eta_box + " days");
            pdfFormFields.SetField("dateCompleted", " ");
            pdfFormFields.SetField("phone", ticket_phone);
            pdfFormFields.SetField("tech", Shared.currentUser._userName.ToString());
            pdfFormFields.SetField("email", ticket_email);
            pdfFormFields.SetField("problemDescription", descritp_box);
            pdfFormFields.SetField("make", make_box);
            pdfFormFields.SetField("model", model_box);
            pdfFormFields.SetField("serial", serial_box);
            pdfFormFields.SetField("passwords", ticket_password);
            pdfFormFields.SetField("accessories", accessories_box);
            pdfFormFields.SetField("defectsField", defects_box);
            check_Type_of_Pc(pdfFormFields);
            check_value_acAdapter(pdfFormFields);
        }
    }
}