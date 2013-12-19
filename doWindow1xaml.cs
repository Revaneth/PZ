     //==================+ button w praca ===========
     /* to :
      <Button x:Name="BttnPraca" Content="Start" HorizontalAlignment="Left" Margin="360,325,0,0" VerticalAlignment="Top" Width="136" Height="52" Click="PracaBttnClick"/>
       
       
     
     do głownego grida tzn po takim czymś :
     
   <!--  <Grid x:Name="LayoutRoot">
        <TabControl Margin="8" Style="{DynamicResource TabControlStyle1}" ItemContainerStyle="{DynamicResource TabItemStyleg1}" Background="#FFF9F9F9">
            <TabItem Header="PROFIL">
                <Grid Background="#FFE5E5E5"> --> 
                
                
     
       
       */  
       
       
    //-----------------------------------------------------------   
       
        private bool zalogowany = false;

        private void PracaBttnClick(object sender, RoutedEventArgs e)
        {
             string CmdS="";
             int id = 0;

             string username = "nik"; //to na jakiejś 'globalnej' jak będzie 



                var format = "yyyy-MM-dd HH:mm:ss:fff";
                var ObecnaData = DateTime.Now.ToString(format);
              //  var convertedBack = DateTime.ParseExact(stringDate, format,  );//to do czytania z powroten na póżniej



            try{

             using (SqlConnection conn = new SqlConnection(
                        "Data Source=(local);Initial Catalog=Baza_PZ;"+
                        "Integrated Security=SSPI" ))
          
                    {
                        conn.Open();

                        if (zalogowany)
                        {
                            
                           
                            CmdS = @"SELECT Id FROM TimeTable 
                 WHERE Id = (SELECT MAX(Id) FROM TimeTable); ";
                            SqlCommand cmd = new SqlCommand(CmdS, conn);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dt = new DataTable();


                            sda.Fill(dt);

                            id = (int)dt.Rows[0][0];


                            if (id != null)
                            {
                                CmdS = @"update TimeTable set czasOut = '" + ObecnaData + "' where Id = " + id;
                                cmd = new SqlCommand(CmdS, conn);
                                cmd.ExecuteNonQuery();
                                System.Diagnostics.Debug.Write("" + id);
                            }



                            zalogowany = false; BttnPraca.Content = "Start"; 
                        }
                        else //niezalogowany
                        {



                            CmdS = @"Insert TimeTable  (nick, czasIN) 
values ('"+username+"', '"+ObecnaData+"' )";

                            SqlCommand cmd = new SqlCommand(CmdS, conn);
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);

                            cmd.ExecuteNonQuery();
                            
                            
                            
                            zalogowany = true; BttnPraca.Content = "Stop"; 
                        }


                        conn.Close();

                    }

           
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        





              
                   



        }
