﻿//
// dbProduct DATABASE TABLE FOR PRODUCT INFORMATION
// ================================================
// This is a class that manages the product table for the database. It is adapted
// from the basic database class and has a customised Data class that provides access
// to the fields in the product table.
//
// Revision History
// ================
// 04.03.2025 BRD Original version.
// 
using System;
using System.IO;
using System.Text.Json;

namespace db {    
    public class dbProduct { 
        // This is used to report errors to the user.
        private string lastError = "";  
        
        private string directoryName = "";
        private string tableName = "";             
                
        // Define the private database table fields provided by the product
        // information table. It uses a private C# class called Table to
        // represent the table.
        private class Table {
            public string productID {get; set;}
            public string productDesc {get; set;}            
            public Single price { get; set; }
        }
        // Define a variable of the type Table. The class gets created later in the
        // Constructor below.
        private Table data; 
                        
        //
        // Constructor
        // ===========
        // The constructor sets up a lot of things that this class needs. Remember
        // the constructor is the first method that runs as soon as the class is
        // created.
        public dbProduct() { 
            // Create an instance of the Table class called "data". The Read()
            // and Update() methods will use this to hold the information found
            // in each database record. The instance holds just one customer record
            // at a time.
            data = new Table();

            // Locate the database folder so that the JSON-format data table can
            // be accessed. It is always located in the bin/Debug folder for
            // the project.            
            directoryName = Directory.GetCurrentDirectory(); 
            
            // Specify the name of the subdirectory that will
            // store the data by setting the tableName variable.
            tableName = "product";
        
            // If the database and table does not exist then create a new one.
            if (!Directory.Exists(directoryName + "\\Database\\" + tableName + "\\")) {
                try {                    
                    Directory.CreateDirectory(directoryName + "\\Database\\" + tableName + "\\");
                } catch {
                    lastError = "Cannot create database in directory " + directoryName;  
                }
            }            
        }
        
        //
        // ProductID
        // =========
        // This get/set provides the product maintenance form with public access to this
        // field in the database table. It persists this field for the form to use again and
        // again in the internal Table class. Remember, the data in the data object is private
        // but this is a public method that the Product Maintenance or other forms can use
        // to get information from the product information table.
        public string ProductID {
            get {return data.productID; }
            set {data.productID = value; }
        }

        //
        // ProductDesc
        // ===========
        public string ProductDesc {
            get {return data.productDesc; }
            set {data.productDesc = value; }
        }

        //
        // Price
        // =====
        public Single Price {
            get {return data.price; }
            set {data.price = value; }
        }
        
        //
        // LastError 
        // =========
        // Returns the last error message generated by this class.
        //
        public string LastError {
            get { return lastError; }                
        }

        //
        // Read
        // ====
        // Reads the specified record from the database table and unpacks the data in the
        // record if it is found. If the record is not found, all the database entries are
        // automatically set blank so a new record can be created by the program later
        // if necessary.
        //
        public Boolean Read(string ID) {
            lastError = "";
            Boolean found = false; 

            // Open the JSON file, read to the end, and convert the JSON data to a single object
            // with named fields. This is called deserialising.            
            try {
                StreamReader reader = new StreamReader(directoryName + "\\Database\\" + tableName + "\\" + ID); 
                string json = reader.ReadToEnd();
                reader.Close();

                // The options variable sets up the parameters to make the DeSerialiszer 
                // case insensitive.
                var JsonOptions = new JsonSerializerOptions();
                JsonOptions.PropertyNameCaseInsensitive = true;                    
                data = JsonSerializer.Deserialize<Table>(json, JsonOptions);                
                found = true;
            } catch (Exception e) {
                // the record was not found.
                lastError = e.Message;                  
            } 
            return found;        
        }
                 
        //
        // Update
        // ======
        // This function updates an existing record or creates a new one.
        // Before calling this function, the calling form needs to update
        // each of the data fields.
        // 
        public Boolean Update(string ID) {
            Boolean updated = false;
            string json = "";
            lastError = "";

            if (ID.Trim() == "") {
                lastError = "The record ID is blank"; 
            } else {
                // The options variable sets up the parameters to make the Serialiszer 
                // format the JSON values indented on individual lines. They are easier
                // to read that way when the file is opened later in a text editor.
                var options = new JsonSerializerOptions() {
                    WriteIndented = true
                };

                // Create the JSON format record for the table
                json = JsonSerializer.Serialize(data, options);

                // Write the record to the table
                try {
                    StreamWriter writer = new StreamWriter(directoryName + "\\Database\\" + tableName + "\\" + ID);
                    writer.Write(json);                    
                    writer.Close();
                    updated = true;
                } catch (Exception e) {
                    // the record could not be written, but the catch stops the 
                    // system crashing.
                    lastError = "Could not write JSON text to the file. Error returned: \n\n" + e.Message;
                }
            }
            return updated;
        }           

        //
        // Query
        // =====
        // Returns a string array containing the IDs of all  the records in the table.
        // This can be used to make a list to display in a ListBox or in a ComboBox.
        // 
        public string[] Query() {            
            string[] recordList = Directory.GetFiles(directoryName + "\\Database\\" + tableName);
            
            for (int ptr = 0; ptr < recordList.Length;  ptr++) {                
                // Extract just the file name from the list of files.               
               recordList[ptr] = Path.GetFileName(recordList[ptr]);                
            }                        
            return recordList;
        }        
    }     
}    
 