﻿using huypq.SmtWpfClient.Abstraction;
using huypq.SmtWpfClientSQL.Demo.Dto;
using huypq.SmtWpfClientSQL.Demo.DataModel;

namespace huypq.SmtWpfClientSQL.Demo.View
{
    public partial class tNhapHangView : BaseView<tNhapHangDto, tNhapHangDataModel>
    {
        partial void InitUIPartial();

        public tNhapHangView() : base()
        {
            InitializeComponent();

            InitUIPartial();
        }
    }
}
