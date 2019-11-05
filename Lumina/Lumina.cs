using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using Lumina.Data;
using Lumina.Misc;

// ReSharper disable MemberCanBePrivate.Global

namespace Lumina
{
    public class Lumina
    {
        public DirectoryInfo DataPath { get; private set; }

        public Dictionary< string, Repository > Repositories { get; private set; }

        public static LuminaOptions Options { get; private set; }

        /// <summary>
        /// Constructs a new Lumina object allowing access to game data.
        /// </summary>
        /// <param name="dataPath">Path to the sqpack directory</param>
        /// <param name="options">Options object to provide additional configuration</param>
        /// <exception cref="DirectoryNotFoundException">Thrown when the sqpack directory supplied is missing.</exception>
        public Lumina( string dataPath, LuminaOptions options = null )
        {
            Contract.Requires( dataPath != null );
            Contract.Ensures( Options != null );
            Contract.Ensures( Repositories != null );

            Options = options ?? new LuminaOptions();

            DataPath = new DirectoryInfo( dataPath );

            if( !DataPath.Exists )
            {
                throw new DirectoryNotFoundException( "DataPath provided is missing." );
            }

            Repositories = new Dictionary< string, Repository >();
            foreach( var repo in DataPath.GetDirectories() )
            {
                Repositories[ repo.Name.ToLowerInvariant() ] = new Repository( repo );
            }
        }

        public FileResource GetFile( string path )
        {
            return GetFile< FileResource >( path );
        }

        public T GetFile< T >( string path ) where T : FileResource
        {
            var pathParts = path.Split( '/' );
            var category = pathParts.First();

            var hash = GetFileHash( path );

            var repoName = pathParts[ 1 ].StartsWith( "ex" ) ? pathParts[ 1 ] : "ffxiv";
            var repo = Repositories[ repoName ];

            return repo.GetFile< T >( category, hash );
        }

        public bool FileExists( string path )
        {
            var pathParts = path.Split( '/' );
            var category = pathParts.First();

            var hash = GetFileHash( path );

            var repoName = pathParts[1].StartsWith( "ex" ) ? pathParts[1] : "ffxiv";
            var repo = Repositories[repoName];

            return repo.FileExists( category, hash );
        }

        public UInt64 GetFileHash( string path )
        {
            var pathParts = path.Split( '/' );
            var filename = pathParts.Last();
            var folder = path.Substring( 0, path.LastIndexOf( '/' ) );

            return (UInt64) Crc32.Get( folder ) << 32 | Crc32.Get( filename );
        }
    }
}