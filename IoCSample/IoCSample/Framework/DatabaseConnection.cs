﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IoCSample.Framework
{
    public class DatabaseConnection
    {
        public DatabaseConnection(DatabaseConfiguration configuration)
        {
        }

        public SqlResult ExecuteQuery(string sql)
        {
            throw new NotImplementedException();
        }

        public void ExecuteNonQuery(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
