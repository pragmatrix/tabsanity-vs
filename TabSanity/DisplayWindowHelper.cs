using Microsoft.VisualStudio.Language.Intellisense;
using Microsoft.VisualStudio.Text.Editor;

namespace TabSanity
{
	internal sealed class DisplayWindowHelper
	{
		private ICompletionBroker _completionBroker;
		private ISignatureHelpBroker _signatureHelpBroker;

		private DisplayWindowHelper(
			ITextView view,
			ICompletionBroker completionBroker,
			ISignatureHelpBroker signatureHelpBroker)
			: this(completionBroker, signatureHelpBroker)
		{
			TextView = view;
		}

		internal DisplayWindowHelper(
			ICompletionBroker completionBroker,
			ISignatureHelpBroker signatureHelpBroker)
		{
			_completionBroker = completionBroker;
			_signatureHelpBroker = signatureHelpBroker;
		}

		internal DisplayWindowHelper ForTextView(ITextView view)
		{
			return new DisplayWindowHelper(
				view,
				_completionBroker,
				_signatureHelpBroker);
		}

		internal ITextView TextView { get; private set; }

		internal bool IsCompletionActive
		{
			get { return _completionBroker != null ? _completionBroker.IsCompletionActive(this.TextView) : false; }
		}

		internal bool IsSignatureHelpActive
		{
			get { return _signatureHelpBroker != null ? _signatureHelpBroker.IsSignatureHelpActive(this.TextView) : false; }
		}
	}
}
