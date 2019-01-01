﻿using System.Collections;
using System.Linq;
using Scrmizu;
using UnityEngine;
using UnityEngine.UI;

namespace Scrmizu_Sample
{
    [RequireComponent(typeof(RectTransform))]
    public class HorizontalScrollItem : MonoBehaviour, IInfiniteScrollItem
    {
        private ScrollItemData _data;

        private Text _title;
        private Text _count;
        private Text _value;

        private Text Title => _title != null
            ? _title
            : _title = GetComponentsInChildren<Text>().FirstOrDefault(text => text.name == "Title");

        private Text Count => _count != null
            ? _count
            : _count = GetComponentsInChildren<Text>().FirstOrDefault(text => text.name == "Count");

        private Text Value => _value != null
            ? _value
            : _value = GetComponentsInChildren<Text>().FirstOrDefault(text => text.name == "Value");

        public void UpdateItemData(object data)
        {
            if (!(data is ScrollItemData scrollingItemData)) return;
            gameObject.SetActive(true);
            if (_data == scrollingItemData) return;
            _data = scrollingItemData;
            Title.text = _data.title;
            Count.text = $"Count {_data.count:00}";
            Value.text = "横幅の最低サイズはこのぐらいです。　　　　\n" + _data.value.Replace("\n", "");
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}