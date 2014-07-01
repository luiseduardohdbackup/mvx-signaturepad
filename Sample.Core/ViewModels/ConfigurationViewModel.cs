﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using Acr.MvvmCross.Plugins.SignaturePad;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.UI;


namespace Sample.Core.ViewModels {

    public class ColorDefinition {
        public string Name { get; set; }
        public MvxColor Color { get; set; }
    }


    public class ConfigurationViewModel : MvxViewModel {
        private readonly ISignatureService signatureService;


        public ConfigurationViewModel(ISignatureService signatureService) {
            this.signatureService = signatureService;
            this.Colors = typeof(MvxColors)
                .GetTypeInfo()
                .DeclaredFields
                .Select(x => new ColorDefinition {
                    Name = x.Name,
                    Color = (MvxColor)x.GetValue(null)
                })
                .ToList();

            var cfg = this.signatureService.Configuration;
            this.saveText = cfg.SaveText;
            this.cancelText = cfg.CancelText;
            this.promptText = cfg.PromptText;
            this.captionText = cfg.CaptionText;

            this.bgColor = this.GetColorDefinition(cfg.BackgroundColor);
            this.promptTextColor = this.GetColorDefinition(cfg.PromptTextColor);
            this.captionTextColor = this.GetColorDefinition(cfg.CaptionTextColor);
            this.signatureLineColor = this.GetColorDefinition(cfg.SignatureLineColor);
            this.strokeColor = this.GetColorDefinition(cfg.StrokeColor);
        }

        #region Internals

        private ColorDefinition GetColorDefinition(MvxColor color) {
            return this.Colors.FirstOrDefault(x => x.Color.ARGB == color.ARGB);
        }


        private void FirePropertyChanged([CallerMemberName] string propertyName = null) {
            this.RaisePropertyChanged(propertyName);
        }


        private bool SetPropertyChange<T>(ref T property, T value, [CallerMemberName] string propertyName = null){
            if (Object.Equals(property, value)) 
                return false;

            property = value;
            this.RaisePropertyChanged(propertyName);

            return true;
        }

        #endregion

        #region Binding Properties

        public IList<ColorDefinition> Colors { get; private set; }


        private string cancelText;
        public string CancelText {
            get { return this.cancelText; }
            set { 
                if (this.SetPropertyChange(ref this.cancelText, value))
                    this.signatureService.Configuration.CancelText = value;
            }
        }


        private string saveText;
        public string SaveText {
            get { return this.saveText; }
            set { 
                if (this.SetPropertyChange(ref this.saveText, value))
                    this.signatureService.Configuration.SaveText = value;
            }
        }


        private string promptText;
        public string PromptText {
            get { return this.promptText; }
            set {
                if (this.SetPropertyChange(ref this.promptText, value))
                    this.signatureService.Configuration.PromptText = value;
            }
        }


        private string captionText;
        public string CaptionText {
            get { return this.captionText; }
            set {
                if (this.SetPropertyChange(ref this.captionText, value))
                    this.signatureService.Configuration.CaptionText = value;
            }
        }


        private float strokeWidth;
        public float StrokeWidth {
            get { return this.strokeWidth; }
            set {
                if (this.SetPropertyChange(ref this.strokeWidth, value))
                    this.signatureService.Configuration.StrokeWidth = value;
            }
        }

        public ColorDefinition signatureLineColor;
        public ColorDefinition SignatureLineColor {
            get { return this.signatureLineColor; }
            set {
                if (this.SetPropertyChange(ref this.signatureLineColor, value))
                    this.signatureService.Configuration.SignatureLineColor = value.Color;
            }
        }


        private ColorDefinition strokeColor;
        public ColorDefinition StrokeColor {
            get { return this.strokeColor; }
            set {
                if (this.SetPropertyChange(ref this.strokeColor, value))
                    this.signatureService.Configuration.StrokeColor = value.Color;
            }
        }


        private ColorDefinition captionTextColor;
        public ColorDefinition CaptionTextColor {
            get { return this.captionTextColor; }
            set {
                if (this.SetPropertyChange(ref this.captionTextColor, value))
                    this.signatureService.Configuration.CaptionTextColor = value.Color;
            }
        }


        private ColorDefinition bgColor;
        public ColorDefinition BgColor {
            get { return this.bgColor; }
            set {
                if (this.SetPropertyChange(ref this.bgColor, value))
                    this.signatureService.Configuration.BackgroundColor = value.Color;
            }
        }


        private ColorDefinition promptTextColor;
        public ColorDefinition PromptTextColor {
            get { return this.promptTextColor; }
            set {
                if (this.SetPropertyChange(ref this.promptTextColor, value))
                    this.signatureService.Configuration.PromptTextColor = value.Color;
            }
        }

        #endregion
    }
}
