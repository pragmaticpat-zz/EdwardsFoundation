﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JoanCEdwards.DAO
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EdwardsFoundation")]
	public partial class ExamSystemDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUserProfile(UserProfile instance);
    partial void UpdateUserProfile(UserProfile instance);
    partial void DeleteUserProfile(UserProfile instance);
    partial void InsertExam(Exam instance);
    partial void UpdateExam(Exam instance);
    partial void DeleteExam(Exam instance);
    partial void InsertChoice(Choice instance);
    partial void UpdateChoice(Choice instance);
    partial void DeleteChoice(Choice instance);
    partial void InsertQuestion(Question instance);
    partial void UpdateQuestion(Question instance);
    partial void DeleteQuestion(Question instance);
    #endregion
		
		public ExamSystemDataContext() : 
				base(global::JoanCEdwards.DAO.Properties.Settings.Default.EdwardsFoundationConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public ExamSystemDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExamSystemDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExamSystemDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ExamSystemDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<UserProfile> UserProfiles
		{
			get
			{
				return this.GetTable<UserProfile>();
			}
		}
		
		public System.Data.Linq.Table<Exam> Exams
		{
			get
			{
				return this.GetTable<Exam>();
			}
		}
		
		public System.Data.Linq.Table<Choice> Choices
		{
			get
			{
				return this.GetTable<Choice>();
			}
		}
		
		public System.Data.Linq.Table<Question> Questions
		{
			get
			{
				return this.GetTable<Question>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DeleteUser")]
		public int DeleteUser([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserId", DbType="Int")] System.Nullable<int> userId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userId);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.DeleteExam")]
		public int DeleteExam([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ExamId", DbType="Int")] System.Nullable<int> examId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), examId);
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserProfile")]
	public partial class UserProfile : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _UserId;
		
		private string _FirstName;
		
		private string _LastName;
		
		private string _EmailAddress;
		
		private char _UserType;
		
		private string _GradeLevel;
		
		private bool _Status;
		
		private string _Password;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    partial void OnEmailAddressChanging(string value);
    partial void OnEmailAddressChanged();
    partial void OnUserTypeChanging(char value);
    partial void OnUserTypeChanged();
    partial void OnGradeLevelChanging(string value);
    partial void OnGradeLevelChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    #endregion
		
		public UserProfile()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EmailAddress", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string EmailAddress
		{
			get
			{
				return this._EmailAddress;
			}
			set
			{
				if ((this._EmailAddress != value))
				{
					this.OnEmailAddressChanging(value);
					this.SendPropertyChanging();
					this._EmailAddress = value;
					this.SendPropertyChanged("EmailAddress");
					this.OnEmailAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserType", DbType="Char(1) NOT NULL")]
		public char UserType
		{
			get
			{
				return this._UserType;
			}
			set
			{
				if ((this._UserType != value))
				{
					this.OnUserTypeChanging(value);
					this.SendPropertyChanging();
					this._UserType = value;
					this.SendPropertyChanged("UserType");
					this.OnUserTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GradeLevel", DbType="Char(10) NOT NULL", CanBeNull=false)]
		public string GradeLevel
		{
			get
			{
				return this._GradeLevel;
			}
			set
			{
				if ((this._GradeLevel != value))
				{
					this.OnGradeLevelChanging(value);
					this.SendPropertyChanging();
					this._GradeLevel = value;
					this.SendPropertyChanged("GradeLevel");
					this.OnGradeLevelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(300)")]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Exam")]
	public partial class Exam : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ExamId;
		
		private string _Title;
		
		private string _Instructions;
		
		private bool _Status;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnExamIdChanging(int value);
    partial void OnExamIdChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnInstructionsChanging(string value);
    partial void OnInstructionsChanged();
    partial void OnStatusChanging(bool value);
    partial void OnStatusChanged();
    #endregion
		
		public Exam()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExamId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ExamId
		{
			get
			{
				return this._ExamId;
			}
			set
			{
				if ((this._ExamId != value))
				{
					this.OnExamIdChanging(value);
					this.SendPropertyChanging();
					this._ExamId = value;
					this.SendPropertyChanged("ExamId");
					this.OnExamIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Instructions", DbType="NVarChar(MAX)")]
		public string Instructions
		{
			get
			{
				return this._Instructions;
			}
			set
			{
				if ((this._Instructions != value))
				{
					this.OnInstructionsChanging(value);
					this.SendPropertyChanging();
					this._Instructions = value;
					this.SendPropertyChanged("Instructions");
					this.OnInstructionsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this.OnStatusChanging(value);
					this.SendPropertyChanging();
					this._Status = value;
					this.SendPropertyChanged("Status");
					this.OnStatusChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Choice")]
	public partial class Choice : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ChoiceId;
		
		private string _Label;
		
		private int _Value;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnChoiceIdChanging(int value);
    partial void OnChoiceIdChanged();
    partial void OnLabelChanging(string value);
    partial void OnLabelChanged();
    partial void OnValueChanging(int value);
    partial void OnValueChanged();
    #endregion
		
		public Choice()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ChoiceId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ChoiceId
		{
			get
			{
				return this._ChoiceId;
			}
			set
			{
				if ((this._ChoiceId != value))
				{
					this.OnChoiceIdChanging(value);
					this.SendPropertyChanging();
					this._ChoiceId = value;
					this.SendPropertyChanged("ChoiceId");
					this.OnChoiceIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Label", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Label
		{
			get
			{
				return this._Label;
			}
			set
			{
				if ((this._Label != value))
				{
					this.OnLabelChanging(value);
					this.SendPropertyChanging();
					this._Label = value;
					this.SendPropertyChanged("Label");
					this.OnLabelChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Value", DbType="Int NOT NULL")]
		public int Value
		{
			get
			{
				return this._Value;
			}
			set
			{
				if ((this._Value != value))
				{
					this.OnValueChanging(value);
					this.SendPropertyChanging();
					this._Value = value;
					this.SendPropertyChanged("Value");
					this.OnValueChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Question")]
	public partial class Question : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _QuestionId;
		
		private string _QuestionCategory;
		
		private string _QuestionType;
		
		private string _QuestionText;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnQuestionIdChanging(int value);
    partial void OnQuestionIdChanged();
    partial void OnQuestionCategoryChanging(string value);
    partial void OnQuestionCategoryChanged();
    partial void OnQuestionTypeChanging(string value);
    partial void OnQuestionTypeChanged();
    partial void OnQuestionTextChanging(string value);
    partial void OnQuestionTextChanged();
    #endregion
		
		public Question()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestionId", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int QuestionId
		{
			get
			{
				return this._QuestionId;
			}
			set
			{
				if ((this._QuestionId != value))
				{
					this.OnQuestionIdChanging(value);
					this.SendPropertyChanging();
					this._QuestionId = value;
					this.SendPropertyChanged("QuestionId");
					this.OnQuestionIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestionCategory", DbType="VarChar(50)")]
		public string QuestionCategory
		{
			get
			{
				return this._QuestionCategory;
			}
			set
			{
				if ((this._QuestionCategory != value))
				{
					this.OnQuestionCategoryChanging(value);
					this.SendPropertyChanging();
					this._QuestionCategory = value;
					this.SendPropertyChanged("QuestionCategory");
					this.OnQuestionCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestionType", DbType="NChar(10)")]
		public string QuestionType
		{
			get
			{
				return this._QuestionType;
			}
			set
			{
				if ((this._QuestionType != value))
				{
					this.OnQuestionTypeChanging(value);
					this.SendPropertyChanging();
					this._QuestionType = value;
					this.SendPropertyChanged("QuestionType");
					this.OnQuestionTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_QuestionText", DbType="NVarChar(MAX)")]
		public string QuestionText
		{
			get
			{
				return this._QuestionText;
			}
			set
			{
				if ((this._QuestionText != value))
				{
					this.OnQuestionTextChanging(value);
					this.SendPropertyChanging();
					this._QuestionText = value;
					this.SendPropertyChanged("QuestionText");
					this.OnQuestionTextChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
