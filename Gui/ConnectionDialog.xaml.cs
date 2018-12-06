﻿using LINQPad.Extensibility.DataContext;
using System.Windows;

namespace AzureDevOpsDataContextDriver
{
    public partial class ConnectionDialog : Window
    {
        IConnectionInfo _cxInfo;
        AzureDevOpsConnectionInfo _connInfo;

        public ConnectionDialog(IConnectionInfo cxInfo)
        {
            _cxInfo = cxInfo;
            _connInfo = new AzureDevOpsConnectionInfo(cxInfo);
            DataContext = _connInfo;
            InitializeComponent();
        }

        void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_connInfo.Uri))
            {
                MessageBox.Show("Please enter a valid Azure DevOps URL.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(_connInfo.Token))
            {
                MessageBox.Show("Please enter a valid Azure DevOps Token.", Title, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            DialogResult = true;
        }
    }
}
