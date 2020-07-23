// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.TransformSynchronization
{
    public class CompressedQuaternionRenderer : SchemaTypeVisualElement<global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion>
    {
        private readonly TextField dataField;

        public CompressedQuaternionRenderer(string label) : base(label)
        {
            dataField = new TextField("Data");
            dataField.SetEnabled(false);
            Container.Add(dataField);
        }

        public override void Update(global::Improbable.Gdk.TransformSynchronization.CompressedQuaternion data)
        {
            dataField.value = data.Data.ToString();
        }
    }
}
