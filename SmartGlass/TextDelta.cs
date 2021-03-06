﻿using System;
using SmartGlass.Common;

namespace SmartGlass
{
    internal class TextDelta : ISerializable
    {
        public uint Offset { get; set; }
        public uint DeleteCount { get; set; }
        public string InsertContent { get; set; }

        public void Deserialize(BEReader reader)
        {
            Offset = reader.ReadUInt32();
            DeleteCount = reader.ReadUInt32();
            InsertContent = reader.ReadUInt16PrefixedString();
        }

        public void Serialize(BEWriter writer)
        {
            writer.Write(Offset);
            writer.Write(DeleteCount);
            writer.WriteUInt16Prefixed(InsertContent);
        }
    }
}
