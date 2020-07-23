// =====================================================
// DO NOT EDIT - this file is automatically regenerated.
// =====================================================

using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Improbable.Gdk.Debug.WorkerInspector.Codegen;

namespace Improbable.Gdk.TransformSynchronization
{
    public class FixedPointVector3Renderer : SchemaTypeVisualElement<global::Improbable.Gdk.TransformSynchronization.FixedPointVector3>
    {
        private readonly TextField xField;
        private readonly TextField yField;
        private readonly TextField zField;

        public FixedPointVector3Renderer(string label) : base(label)
        {
            xField = new TextField("X");
            xField.SetEnabled(false);
            Container.Add(xField);

            yField = new TextField("Y");
            yField.SetEnabled(false);
            Container.Add(yField);

            zField = new TextField("Z");
            zField.SetEnabled(false);
            Container.Add(zField);
        }

        public override void Update(global::Improbable.Gdk.TransformSynchronization.FixedPointVector3 data)
        {
            xField.value = data.X.ToString();
            yField.value = data.Y.ToString();
            zField.value = data.Z.ToString();
        }
    }
}
