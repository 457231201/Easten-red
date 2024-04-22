// Copyright 2022-2024 Niantic.
using System.Linq;
using Niantic.Lightship.AR.Semantics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class SemanticQuerying : MonoBehaviour
{
    public ARCameraManager _cameraMan; //摄像机
    public ARSemanticSegmentationManager _semanticMan; //遮蔽对象

    public RawImage _image;  //未加工图像
    public Material _material;

    private string _semanticChannelName = string.Empty;  //语义通道名字

   // private string _channel = "sky"; //通道

    [SerializeField]
    private Dropdown _channelDropdown; //下拉菜单

    void OnEnable() //启用
    {
        _cameraMan.frameReceived += OnCameraFrameUpdate; //摄像机帧更新
        _channelDropdown.onValueChanged.AddListener(ChannelDropdown_OnValueChanged);  //下拉菜单值改变

        _semanticMan.MetadataInitialized += SemanticsManager_OnDataInitialized; //语义数据初始化

    }

    private void OnDisable() //禁用
    {
        _cameraMan.frameReceived -= OnCameraFrameUpdate; //摄像机帧更新
    }

    private void OnCameraFrameUpdate(ARCameraFrameEventArgs args) //摄像机帧更新
    {
        if (!_semanticMan.subsystem.running) //如果语义子系统没有运行
        {
            return; //返回
        }

        //get the semantic texture
        Matrix4x4 mat = Matrix4x4.identity;  //矩阵
        var texture = _semanticMan.GetSemanticChannelTexture(_semanticChannelName, out mat);  //获取语义通道纹理

        if (texture) //如果纹理存在
        {
            //the texture needs to be aligned to the screen so get the display matrix
            //and use a shader that will rotate/scale things.
            Matrix4x4 cameraMatrix = args.displayMatrix ?? Matrix4x4.identity; //摄像机矩阵
            _image.material = _material; //材质
            _image.material.SetTexture("_SemanticTex", texture); //设置纹理
            _image.material.SetMatrix("_DisplayMatrix", mat); //设置矩阵
        }
    }

    private void SemanticsManager_OnDataInitialized(ARSemanticSegmentationModelEventArgs args) //语义数据初始化
    {
        // Initialize the channel names in the dropdown menu.
        var channelNames = _semanticMan.ChannelNames;  //通道名字
        _channelDropdown.AddOptions(channelNames.ToList()); //添加选项


        // Display artificial ground by default.
        _semanticChannelName = channelNames[0]; //默认显示sky
        var dropdownList = _channelDropdown.options.Select(option => option.text).ToList(); //下拉菜单选项
        _channelDropdown.value = dropdownList.IndexOf(_semanticChannelName); //下拉菜单值
    }
    private void ChannelDropdown_OnValueChanged(int val) //通道下拉菜单值改变
    {
        // Update the display channel from the dropdown value. 
        _semanticChannelName = _channelDropdown.options[val].text; //更新显示通道
    }
}