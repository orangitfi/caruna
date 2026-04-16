namespace KT.Utils.Mapping
{


    public struct MappingKeyPair
    {

        public MappingKeyPair(string sourceKey, string targetKey)
        {
            this.SourceKey = sourceKey;
            this.TargetKey = targetKey;
        }

        public string SourceKey;
        public string TargetKey;

    }
}