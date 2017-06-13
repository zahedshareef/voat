﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Voat.Common
{
    public enum DataStoreType
    {
        SqlServer,
        PostgreSql
    }
    public enum Origin
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// From the web UI
        /// </summary>
        UI = 1,

        /// <summary>
        /// From the API endpoints
        /// </summary>
        API = 2,

        /// <summary>
        /// From client-side JS
        /// </summary>
        AJAX = 3
    }
}