using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityEngine.UI.Extensions
{
    class RoundedRectangle : MaskableGraphic
    {
        [SerializeField]
        Texture _texture;
        int _vertCT = 0;

        public bool fill = true;
        public Vector4 corners;
        public int sides = 5;


   

        protected override void OnPopulateMesh(VertexHelper vh)
        {
            
            vh.Clear();
            _vertCT = 0;
            float x1, x2, y1, z1, w1, m1, width, height;
            width = rectTransform.rect.width;
            height = rectTransform.rect.height;
            x1 = corners.x / 2f;
            x2 = corners.x / 2f * Mathf.Sqrt(2f);
            y1 = corners.y / 2f;
            z1 = corners.z / 2f;
            w1 = corners.w / 2f;
            m1 = corners.z > corners.w ? 1f - corners.z/height / 2f : 1f - corners.w/height / 2f;

            
            AddRectangle(vh, new Vector4(-x1/width ,-x1/height,(1f - y1/width - x1/width), m1 - x1/height));
            AddRectangle(vh, new Vector4(-x1/width, 0f, 1f - y1/width - x1/width, x1/height));
            AddRectangle(vh, new Vector4(-(1f - y1/width ), -y1/height, y1/width, 1f - y1/height - w1/height));
            AddRectangle(vh, new Vector4(-z1/width, -m1, 1 - z1/width - w1/width, 1-m1));
            AddRectangle(vh, new Vector4(0f, -x1/height, x1/width, 1 - z1/height - x1/height));
            AddCurve(vh, new Vector4(-x1/width, -x1/height, x1, 0f));
            AddCurve(vh, new Vector4(-(1f - y1/width), -y1/height, y1, 45f));
            AddCurve(vh, new Vector4(-(1 - w1 / width), -(1 - w1 / height), w1, 90f));
            AddCurve(vh, new Vector4(-z1/width, -(1 - z1 / height), z1, -45f));
        }

        private void AddCurve(VertexHelper vh, Vector4 rect)
        {
            Vector2 corner1 = Vector2.zero;
            float width, height;

            width = rectTransform.rect.width;
            height = rectTransform.rect.height;

            if (rect == Vector4.zero) return;

            corner1.x = 0f;
            corner1.y = 0f;

            corner1.x -= rectTransform.pivot.x + rect.x;
            corner1.y -= rectTransform.pivot.y + rect.y;

            corner1.x *= rectTransform.rect.width;
            corner1.y *= rectTransform.rect.height;

            UIVertex vert = UIVertex.simpleVert;

            for (int i = 0; i < sides; i++)
            {
                //color = new Color(_vertCT / 60f + 0.01f, _vertCT / 60f + 0.01f, _vertCT / 60f + 0.01f);
                float angle = (((float)i / sides + rect.w) * 90) * Mathf.PI / 180f;
                float angle2 = (((float)(i+1) / sides + rect.w) * 90) * Mathf.PI / 180f;
                //float angle = ((float)i * 10f) * Mathf.PI / 180f;
                //float angle2 = ((float)(i+1) * 10f) * Mathf.PI / 180f;
               // Debug.Log(angle);
                float x1 =  (-rect.z*width * Mathf.Cos(angle))/width;
                float y1 =  (-rect.z*height * Mathf.Sin(angle))/height;
                float x2 =  (-rect.z*width * Mathf.Cos(angle2))/width;
                float y2 =  (-rect.z*height * Mathf.Sin(angle2))/height;

                vert.position = new Vector2(corner1.x, corner1.y);
                vert.color = color;
                vh.AddVert(vert);
                

                vert.position = new Vector2(x1 + corner1.x, y1 + corner1.y);
                vert.color = color;
                vh.AddVert(vert);

                vert.position = new Vector2(x2 + corner1.x, y2 + corner1.y);
                vert.color = color;
                vh.AddVert(vert);


                vh.AddTriangle(0 + _vertCT, 1 + _vertCT, 2 + _vertCT);
                _vertCT += 3;
            }
        }

        private void AddRectangle(VertexHelper vh, Vector4 bounds)
        {
            Vector2 corner1 = Vector2.zero;
            Vector2 corner2 = Vector2.zero;

            if (bounds == Vector4.zero) return;

            corner1.x = 0f;
            corner1.y = 0f;
            corner2.x = bounds.z;
            corner2.y = bounds.w;

            corner1.x -= rectTransform.pivot.x + bounds.x;
            corner1.y -= rectTransform.pivot.y + bounds.y;
            corner2.x -= rectTransform.pivot.x + bounds.x;
            corner2.y -= rectTransform.pivot.y + bounds.y;

            corner1.x *= rectTransform.rect.width;
            corner1.y *= rectTransform.rect.height;
            corner2.x *= rectTransform.rect.width;
            corner2.y *= rectTransform.rect.height;

            UIVertex vert = UIVertex.simpleVert;

            //color = new Color(_vertCT*5/50f+0.01f, _vertCT*5/50f+0.01f, _vertCT*5/50f+0.01f);

            vert.position = new Vector2(corner1.x, corner1.y);
            vert.color = color;
            vh.AddVert(vert);

            vert.position = new Vector2(corner1.x, corner2.y);
            vert.color = color;
            vh.AddVert(vert);

            vert.position = new Vector2(corner2.x, corner2.y);
            vert.color = color;
            vh.AddVert(vert);

            vert.position = new Vector2(corner2.x, corner1.y);
            vert.color = color;
            vh.AddVert(vert);

            vh.AddTriangle(0 + _vertCT, 1 + _vertCT, 2 + _vertCT);
            vh.AddTriangle(2 + _vertCT, 3 + _vertCT, 0 + _vertCT);
            _vertCT += 4;
        }
    }
}
