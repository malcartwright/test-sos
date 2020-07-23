// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Restricted
{
    public class ConnectionRenderer : SchemaTypeVisualElement<global::Improbable.Restricted.Connection>
    {
        private readonly EnumField statusField;
        private readonly TextField dataLatencyMsField;
        private readonly TextField connectedSinceUtcField;

        public ConnectionRenderer(string label) : base(label)
        {
            statusField = new EnumField("Status");
            statusField.SetEnabled(false);
            statusField.Init(default(global::Improbable.Restricted.Connection.ConnectionStatus));
            Container.Add(statusField);

            dataLatencyMsField = new TextField("Data Latency Ms");
            dataLatencyMsField.SetEnabled(false);
            Container.Add(dataLatencyMsField);

            connectedSinceUtcField = new TextField("Connected Since Utc");
            connectedSinceUtcField.SetEnabled(false);
            Container.Add(connectedSinceUtcField);
        }

        public override void Update(global::Improbable.Restricted.Connection data)
        {
            statusField.value = data.Status;
            dataLatencyMsField.value = data.DataLatencyMs.ToString();
            connectedSinceUtcField.value = data.ConnectedSinceUtc.ToString();
        }
    }
}
