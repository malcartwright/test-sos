// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Restricted
{
    public class PlayerIdentityRenderer : SchemaTypeVisualElement<global::Improbable.Restricted.PlayerIdentity>
    {
        private readonly TextField playerIdentifierField;
        private readonly TextField providerField;
        private readonly TextField metadataField;

        public PlayerIdentityRenderer(string label) : base(label)
        {
            playerIdentifierField = new TextField("Player Identifier");
            playerIdentifierField.SetEnabled(false);
            Container.Add(playerIdentifierField);

            providerField = new TextField("Provider");
            providerField.SetEnabled(false);
            Container.Add(providerField);

            metadataField = new TextField("Metadata");
            metadataField.SetEnabled(false);
            Container.Add(metadataField);
        }

        public override void Update(global::Improbable.Restricted.PlayerIdentity data)
        {
            playerIdentifierField.value = data.PlayerIdentifier.ToString();
            providerField.value = data.Provider.ToString();
            metadataField.value = global::System.Text.Encoding.Default.GetString(data.Metadata);
        }
    }
}
