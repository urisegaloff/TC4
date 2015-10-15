﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using ElRaEntity;

namespace ElRaWebUtil
{
    public class SessionHelper
    {
        private SessionHelper()
        {
        }

        public static void AlmacenarUsuarioAutenticado(UsuarioEntity usuario)
        {
            HttpContext.Current.Session.Add("UsuarioAutenticado", usuario);
        }

        public static UsuarioEntity UsuarioAutenticado
        {
            get
            {
                return (UsuarioEntity)HttpContext.Current.Session["UsuarioAutenticado"];
            }
        }
    }
}
