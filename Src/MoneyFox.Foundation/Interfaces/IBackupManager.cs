using System;
using System.Threading.Tasks;
using MoneyFox.Foundation.Exceptions;

namespace MoneyFox.Foundation.Interfaces
{
    /// <summary>
    ///     Defines the interface for a BackupManager who handles the different functions of a backup.
    /// </summary>
    public interface IBackupManager
    {
        /// <summary>
        ///     Login user.
        /// </summary>
        /// <exception cref="BackupAuthenticationFailedException">Thrown when the user couldn't be logged in.</exception>
        Task Login();        
        
        /// <summary>
        ///     Logout user.
        /// </summary>
        Task Logout();

        /// <summary>
        ///     Checks if there are backups to restore.
        /// </summary>
        /// <returns>Backups available or not.</returns>
        /// <exception cref="BackupAuthenticationFailedException">Thrown when the user couldn't be logged in.</exception>
        Task<bool> IsBackupExisting();

        /// <summary>
        ///     Returns the date when the last backup was created.
        /// </summary>
        /// <returns>Creation date of the last backup.</returns>
        /// <exception cref="BackupAuthenticationFailedException">Thrown when the user couldn't be logged in.</exception>
        Task<DateTime> GetBackupDate();

        /// <summary>
        ///     Creates a new backup.
        /// </summary>
        /// <exception cref="BackupAuthenticationFailedException">Thrown when the user couldn't be logged in.</exception>
        Task<bool> CreateNewBackup();

        /// <summary>
        ///     Restores an existing backup.
        /// </summary>
        /// <exception cref="BackupAuthenticationFailedException">Thrown when the user couldn't be logged in.</exception>
        /// <exception cref="NoBackupFoundException">Thrown when no backup with the right name is found.</exception>
        Task RestoreBackup();

        /// <summary>
        ///     Enqueues a new backup task
        /// </summary>
        /// <exception cref="NetworkConnectionException">Thrown if there is no internet connection.</exception>
        Task EnqueueBackupTask(int attempts = 0);

        /// <summary>
        ///     Syncs the local database with the Backupservice and
        ///     restores it if the one on the Backupservice is newer.
        /// </summary>
        /// <exception cref="BackupAuthenticationFailedException">Thrown when the user couldn't be logged in.</exception>
        /// <exception cref="NoBackupFoundException">Thrown when no backup with the right name is found.</exception>
        Task DownloadBackup();
    }
}