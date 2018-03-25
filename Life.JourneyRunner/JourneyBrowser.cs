using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BeagleStreet.Test.Support;
using Life.JourneyRunner.CustomExceptions;
using OpenQA.Selenium;

namespace Life.JourneyRunner
{
    public class JourneyBrowser : IBrowser
    {
        private readonly IBrowser _browser;

        public string PageTitle => _browser.PageTitle;
        public string CurrentUrl => _browser.CurrentUrl;
        public string DisplayedContent => _browser.DisplayedContent;
        public ReadOnlyCollection<Cookie> Cookies => _browser.Cookies;

        public JourneyBrowser(IWebDriver driver)
        {
            _browser = new WebDriverBrowser(driver);    
        }

        public void AddCookie(string name, string value)
        {
            _browser.AddCookie(name, value);
        }

        public void GoTo(string url)
        {
            _browser.GoTo(url);
        }

        public bool IsCurrentlyOn(string url, bool ignoreQueryString, string title)
        {
            return _browser.IsCurrentlyOn(url, ignoreQueryString, title);
        }

        public bool IsCurrentlyOn(string url, bool ignoreQueryString)
        {
            return _browser.IsCurrentlyOn(url, ignoreQueryString);
        }

        public void EnterTextIntoElement(string cssSelector, string text)
        { 
            if (!_browser.ElementIsVisible(cssSelector))
            {
                throw new ElementNotFoundException($"Cannot find the element '{cssSelector}'{Environment.NewLine}Page '{_browser.PageTitle}'{Environment.NewLine}Url: {_browser.CurrentUrl}");
            }

            _browser.EnterTextIntoElement(cssSelector, text);
        }

        public void ClickElementWithCss(string cssSelector)
        {
            if (!_browser.ElementIsVisible(cssSelector))
            {
                throw new ElementNotFoundException($"Cannot find the element '{cssSelector}'{Environment.NewLine}Page '{_browser.PageTitle}'{Environment.NewLine}Url: {_browser.CurrentUrl}");
            }

            _browser.ClickElementWithCss(cssSelector);
        }

        public void ClickElementWithCss(string cssSelector, TimeSpan timeout)
        {
            if (!_browser.ElementIsVisible(cssSelector))
            {
                throw new ElementNotFoundException($"Cannot find the element '{cssSelector}'{Environment.NewLine}Page '{_browser.PageTitle}'{Environment.NewLine}Url: {_browser.CurrentUrl}");
            }

            _browser.ClickElementWithCss(cssSelector, timeout);
        }

        public void ClickElementWithCssAtCoordinates(string cssSelector, int x, int y)
        {
            if (!_browser.ElementIsVisible(cssSelector))
            {
                throw new ElementNotFoundException($"Cannot find the element '{cssSelector}'{Environment.NewLine}Page '{_browser.PageTitle}'{Environment.NewLine}Url: {_browser.CurrentUrl}");
            }

            _browser.ClickElementWithCssAtCoordinates(cssSelector, x, y);
        }

        public void SelectValueFromDropdown(string dropdownCssSelector, string value)
        {
            if (!_browser.ElementIsVisible(dropdownCssSelector))
            {
                throw new ElementNotFoundException($"Cannot find the element '{dropdownCssSelector}'{Environment.NewLine}Page '{_browser.PageTitle}'{Environment.NewLine}Url: {_browser.CurrentUrl}");
            }

            _browser.SelectValueFromDropdown(dropdownCssSelector, value);
        }

        public void SelectTextFromDropdown(string dropdownCssSelector, string text)
        {
            if (!_browser.ElementIsVisible(dropdownCssSelector))
            {
                throw new ElementNotFoundException($"Cannot find the element '{dropdownCssSelector}'{Environment.NewLine}Page '{_browser.PageTitle}'{Environment.NewLine}Url: {_browser.CurrentUrl}");
            }

            _browser.SelectTextFromDropdown(dropdownCssSelector, text);
        }

        public IWebElement FindElement(string cssSelector)
        {
            return _browser.FindElement(cssSelector);
        }

        public IWebElement FindElement(string cssSelector, TimeSpan timeout)
        {
            return _browser.FindElement(cssSelector, timeout);
        }

        public IEnumerable<IWebElement> FindElements(string cssSelector)
        {
            return _browser.FindElements(cssSelector);
        }

        public void WaitForJQueryProcessing(TimeSpan timeout)
        {
            _browser.WaitForJQueryProcessing(timeout);
        }

        public void WaitForElement(string cssSelector, TimeSpan timeout)
        {
            _browser.WaitForElement(cssSelector, timeout);
        }

        public void WaitForElementToAppear(string cssSelector, TimeSpan timeout)
        {
            _browser.WaitForElementToAppear(cssSelector, timeout);
        }

        public string GetText(string selector)
        {
            return _browser.GetText(selector);
        }

        public string GetText(string selector, TimeSpan timeout)
        {
            return _browser.GetText(selector, timeout);
        }

        public bool ElementIsVisible(string selector)
        {
            return _browser.ElementIsVisible(selector);
        }

        public T ExecuteJavaScript<T>(string script, params object[] args)
        {
            return _browser.ExecuteJavaScript<T>(script, args);
        }

        public void ClickBack()
        {
            _browser.ClickBack();
        }

        public void ClickForward()
        {
            _browser.ClickForward();
        }

        public void ClickRefresh()
        {
            _browser.ClickRefresh();
        }

        public void ClickElementByXPath(string xPathString)
        {
            _browser.ClickElementByXPath(xPathString);
        }

        public void Reset(params string[] urlsToClearCookiesOn)
        {
            _browser.Reset(urlsToClearCookiesOn);
        }
    }
}
