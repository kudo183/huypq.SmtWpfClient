﻿using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tChiTietNhapHangView : BaseView<tChiTietNhapHangDto, tChiTietNhapHangDataModel>
    {
        partial void InitUIPartial();

        public tChiTietNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
