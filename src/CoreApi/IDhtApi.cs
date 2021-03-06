﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ipfs.CoreApi
{
    /// <summary>
    ///   Manages the Distributed Hash Table.
    /// </summary>
    /// <remarks>
    ///   The DHT is a place to store, not the value, but pointers to peers who have 
    ///   the actual value.
    /// </remarks>
    /// <seealso href="https://github.com/ipfs/interface-ipfs-core/blob/master/SPEC/DHT.md">DHT API spec</seealso>
    public interface IDhtApi
    {
        /// <summary>
        ///   Information about an IPFS peer.
        /// </summary>
        /// <param name="id">
        ///   The <see cref="MultiHash"/> ID of the IPFS peer.  
        /// </param>
        /// <param name="cancel">
        ///   Is used to stop the task.  When cancelled, the <see cref="TaskCanceledException"/> is raised.
        /// </param>
        Task<Peer> FindPeerAsync(MultiHash id, CancellationToken cancel = default(CancellationToken));

        /// <summary>
        ///   Find the providers for the specified content.
        /// </summary>
        /// <param name="id">
        ///   The <see cref="Cid"/> of the content.
        /// </param>
        /// <param name="cancel">
        ///   Is used to stop the task.  When cancelled, the <see cref="TaskCanceledException"/> is raised.
        /// </param>
        /// <returns>
        ///   A sequence of IPFS <see cref="Peer"/>.
        /// </returns>
        Task<IEnumerable<Peer>> FindProvidersAsync(Cid id, CancellationToken cancel = default(CancellationToken));
    }
}
