﻿// <copyright file="Transaction.cs" company="PetaPoco - CollaboratingPlatypus">
//      Apache License, Version 2.0 https://github.com/CollaboratingPlatypus/PetaPoco/blob/master/LICENSE.txt
// </copyright>
// <author>PetaPoco - CollaboratingPlatypus</author>
// <date>2015/12/05</date>

using System;

namespace PetaPoco
{
    public interface ITransaction : IDisposable
    {
        void Complete();
    }

    /// <summary>
    ///     Transaction object helps maintain transaction depth counts
    /// </summary>
    public class Transaction : ITransaction
    {
        private Database _db;

        public Transaction(Database db)
        {
            _db = db;
            _db.BeginTransaction();
        }

        public void Complete()
        {
            _db.CompleteTransaction();
            _db = null;
        }

        public void Dispose()
        {
            if (_db != null)
                _db.AbortTransaction();
        }
    }
}