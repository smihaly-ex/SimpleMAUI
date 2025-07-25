﻿using SimpleMAUI.Core.Interfaces.ViewModels;

namespace SimpleMAUI.Core.ViewModels;

public class BasePageViewModel : BaseViewModel, IBasePageViewModel
{
    public virtual void OnApplyParameters(IParameters parameters)
    {
    }

    public virtual void OnApplyFirstParameters(IParameters parameters)
    {
    }

    public virtual void OnApplyOtherParameters(IParameters parameters)
    {
    }

    public virtual void OnNavigatedTo()
    {
    }

    public virtual void OnNavigatedFrom()
    {
    }
}
