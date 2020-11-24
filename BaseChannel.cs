using System.Collections.Generic;

namespace LibChaiiLatte {
    internal abstract class BaseChannel {
        public BaseChannel Next;
        protected readonly NetPeer Peer;
        protected readonly Queue<NetPacket> OutgoingQueue;

        protected BaseChannel(NetPeer peer) {
            Peer = peer;
            OutgoingQueue = new Queue<NetPacket>(64);
        }

        public int PacketsInQueue => OutgoingQueue.Count;

        public void AddToQueue(NetPacket packet) {
            lock (OutgoingQueue)
                OutgoingQueue.Enqueue(packet);
        }

        public abstract void SendNextPackets();
        public abstract bool ProcessPacket(NetPacket packet);
    }
}