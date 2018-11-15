﻿using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System;
namespace PalcoNet.Utils {

    public class MenuHelper {

        public static SortedList<int, Funcionalidad> getOptionMenu(int idRol) {
            SortedList<int, Funcionalidad> menuOptions = new SortedList<int, Funcionalidad>();

            SqlConnection conn = Connection.getConnection();

            string storedProcedureName = "LA_MAYORIA.sp_menu_list_functionality_by_user";
            SqlCommand command = new SqlCommand(storedProcedureName);
            command.Connection = conn;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@p_id_rol", idRol);

            SqlDataReader reader = command.ExecuteReader() as SqlDataReader;

            int position = 0;
            if (reader.HasRows) {
                while (reader.Read()) {
                    Funcionalidad menuOption = new Funcionalidad();
                    menuOption.descripcion = reader["Descripcion"].ToString();
                    menuOption.id = Convert.ToInt32(reader["Id_Funcionalidad"]);
                    menuOptions.Add(position, menuOption);
                    position++;
                }
            }

            Connection.close(conn);

            return menuOptions;
        }

        public struct functionality {
            public String folder;
            public String form;
        }

        public static functionality getFunctionality(string id) {
            functionality func = new functionality();

            switch (id) {
                case "Login y Seguridad":
                    func.folder = "Seguridad";
                    func.form = "FormCambiarPassword";
                    break;
                case "ABM de Rol":
                    func.folder = "ABM_de_Rol";
                    func.form = "FormABMRol";
                    break;
                case "ABM de Usuario":
                    func.folder = "ABM_de_Usuario";
                    func.form = "FormABMUsuario";
                    break;
                case "ABM de Hotel":
                    func.folder = "ABM_de_Hotel";
                    func.form = "FormABMHotel";
                    break;
                case "ABM de Cliente":
                    func.folder = "ABM_de_Cliente";
                    func.form = "FormABMClient";
                    break;
                case "ABM de Habitacion":
                    func.folder = "ABM_de_Habitacion";
                    func.form = "FormABMHabitacion";
                    break;
                case "ABM de Regimen":
                    func.folder = "ABM_de_Regimen";
                    func.form = "FormABMRegimen";
                    break;
                case "Cancelar Reserva":
                    func.folder = "Cancelar_Reserva";
                    func.form = "FormCancelarReserva";
                    break;
                case "Registrar Estadía":
                    func.folder = "Registrar_Estadia";
                    func.form = "FormRegistrarEstadia";
                    break;
                case "Registrar Consumibles":
                    func.folder = "Registrar_Consumible";
                    func.form = "FormABMConsumibles";
                    break;
                case "Facturar Publicaciones":
                    func.folder = "Facturar_Publicaciones";
                    func.form = "FormFacturarPublicaciones";
                    break;
                case "ABM de Reserva":
                    func.folder = "ABM_de_Reserva";
                    func.form = "FormABMReserva";
                    break;
                case "Listado Estadistico":
                    func.folder = "Listado_Estadistico";
                    func.form = "FormListadoEstadistico";
                    break;
            }
            return func;
        }
    }
}