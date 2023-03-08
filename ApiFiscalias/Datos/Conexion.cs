using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using ApiFiscalias.Models;

namespace ApiFiscalias.Datos
{
    public class Conexion
    {
        public bool InsertFiscalias(Fiscalias fiscalia) {
            string conString = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "EXECUTE SP_INSERT @Nombre_Fiscalia, @Ubicacion, @Numero, @Extension";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Nombre_Fiscalia", fiscalia.Nombre_Fiscalia);
                        cmd.Parameters.AddWithValue("@Ubicacion", fiscalia.Ubicacion);
                        cmd.Parameters.AddWithValue("@Numero", fiscalia.Numero);
                        cmd.Parameters.AddWithValue("@Extension", fiscalia.Extension);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool UpdateFiscalias(Fiscalias fiscalia)
        {
            string conString = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "EXECUTE SP_EDITAR @Id_Fiscalia, @Nombre_Fiscalia, @Ubicacion";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Fiscalia", fiscalia.Id_Fiscalia);
                        cmd.Parameters.AddWithValue("@Nombre_Fiscalia", fiscalia.Nombre_Fiscalia);
                        cmd.Parameters.AddWithValue("@Ubicacion", fiscalia.Ubicacion);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteFiscalias(int id)
        {
            string conString = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "EXECUTE SP_ELIMINAR @Id_Fiscalia";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Fiscalia", id);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public Fiscalias GetFiscalias(int id)
        {
            string constring = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            Fiscalias fiscalia = new Fiscalias();
            try
            {
                SqlDataReader reader = null;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM VW_FISCALIASYNUM where Id_Fiscalia = @Id_Fiscalia", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Fiscalia", id);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                fiscalia.Id_Fiscalia = Convert.ToInt32(reader.GetValue(0));
                                fiscalia.Nombre_Fiscalia = Convert.ToString(reader.GetValue(1));
                                fiscalia.Ubicacion = Convert.ToString(reader.GetValue(2));
                                fiscalia.Numero = Convert.ToDecimal(reader.GetValue(3));
                                fiscalia.Extension = Convert.ToDecimal(reader.GetValue(4));
                            }
                        else
                            return null;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return fiscalia;
        }
        internal List<Fiscalias> GetAllFiscalias()
        {
            string constring = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            Fiscalias fiscalia;
            List<Fiscalias> LisFiscalias = new List<Fiscalias>();
            try
            {
                SqlDataReader reader = null;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand
                        ("SELECT * FROM VW_FISCALIAS", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                fiscalia = new Fiscalias();
                                fiscalia.Id_Fiscalia = Convert.ToInt32(reader.GetValue(0));
                                fiscalia.Nombre_Fiscalia = Convert.ToString(reader.GetValue(1));
                                fiscalia.Ubicacion = Convert.ToString(reader.GetValue(2));
                                LisFiscalias.Add(fiscalia);
                            }
                        else
                            return null;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return LisFiscalias;
        }

        public bool InsertTelefonos(Telefonos fiscalia)
        {
            string conString = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "EXECUTE SP_ADDNUMERO @Id_Fiscalia, @Numero, @Extension";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Fiscalia", fiscalia.Id_Fiscalia);
                        cmd.Parameters.AddWithValue("@Numero", fiscalia.Numero);
                        cmd.Parameters.AddWithValue("@Extension", fiscalia.Extension);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool DeleteTelefonos(int id)
        {
            string conString = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            try
            {
                using (SqlConnection con = new SqlConnection(conString))
                {
                    string comando = "EXECUTE SP_ELIMINARTEL @Id_Telefono";
                    using (SqlCommand cmd = new SqlCommand(comando, con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Telefono", id);
                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                            return true;
                        else
                            return false;
                    }
                }

            }
            catch (Exception ex)
            {
                return false;
            }

        }
        
        public Telefonos GetTelefonos(int id)
        {
            string constring = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            Telefonos telefono = new Telefonos();
            try
            {
                SqlDataReader reader = null;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM VW_TELEFONOS where Id_Telefono = @Id_Telefono", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Telefono", id);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                telefono.Id_Fiscalia = Convert.ToInt32(reader.GetValue(0));
                                telefono.Id_Telefonos = Convert.ToInt32(reader.GetValue(1));
                                telefono.Nombre_Fiscalia = Convert.ToString(reader.GetValue(2));
                                telefono.Ubicacion = Convert.ToString(reader.GetValue(3));
                                telefono.Numero = Convert.ToDecimal(reader.GetValue(4));
                                telefono.Extension = Convert.ToDecimal(reader.GetValue(5));
                            }
                        else
                            return null;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return telefono;
        }

        internal List<Telefonos> GetTelefonosFis(int id)
        {
            string constring = "Data Source= GUERRA; Initial Catalog= FiscaliasMP; User ID=sa; Password= Guerra99";
            Telefonos telefono = new Telefonos();
            List<Telefonos> LisTelefonos = new List<Telefonos>();
            try
            {
                SqlDataReader reader = null;

                using (SqlConnection con = new SqlConnection(constring))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM VW_TELEFONOS where Id_Fiscalia = @Id_Fiscalia", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Id_Fiscalia", id);
                        con.Open();
                        reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                            while (reader.Read())
                            {
                                telefono = new Telefonos();
                                telefono.Id_Fiscalia = Convert.ToInt32(reader.GetValue(0));
                                telefono.Id_Telefonos = Convert.ToInt32(reader.GetValue(1));
                                telefono.Nombre_Fiscalia = Convert.ToString(reader.GetValue(2));
                                telefono.Ubicacion = Convert.ToString(reader.GetValue(3));
                                telefono.Numero = Convert.ToDecimal(reader.GetValue(4));
                                telefono.Extension = Convert.ToDecimal(reader.GetValue(5));
                                LisTelefonos.Add(telefono);
                            }
                        else
                            return null;

                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return LisTelefonos;
        }
    }
}