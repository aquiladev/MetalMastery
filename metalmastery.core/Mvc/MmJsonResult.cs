using System.Collections.Generic;
using System.Web.Mvc;

namespace MetalMastery.Core.Mvc
{
    public class MmJsonResult : JsonResult
    {
        /// <summary>
        /// Gets or sets the state of the result.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the list of errors which might be a model validation errors or some other errors.
        /// </summary>
        public IList<string> Errors
        {
            get
            {
                if (_errors == null)
                    _errors = new List<string>();
                return _errors;
            }
            set { _errors = value; }
        }
        private IList<string> _errors;

        /// <summary>
        ///  Gets or sets data which should be used to validate form.
        /// </summary>
        public object Validators { get; set; }

        /// <summary>
        /// Creates an instance of the DefaultJsonResult
        /// </summary>
        /// <param name="data">Data which should be returned as json</param>
        /// <param name="validators">Data which should be used to validate form</param>
        /// <param name="jsonRequestBehavior"></param>
        /// <param name="success">Represents the state of the result.</param>
        /// <param name="errors"> </param>
        public MmJsonResult(
            object data,
            object validators = null,
            JsonRequestBehavior jsonRequestBehavior = JsonRequestBehavior.AllowGet,
            bool success = true,
            IList<string> errors = null)
        {
            JsonRequestBehavior = jsonRequestBehavior;
            Data = data;
            Validators = validators;
            Success = success;
            _errors = errors;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            Data = new { Data, Validators, Success, Errors };
            base.ExecuteResult(context);
        }
    }
}
