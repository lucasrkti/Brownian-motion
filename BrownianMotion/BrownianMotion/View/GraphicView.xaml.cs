using BrownianMotion.ViewModel;

namespace BrownianMotion.View;

public partial class GraphicView : ContentPage
{
	public GraphicView()
	{
		InitializeComponent();
		BindingContext = new GraphicsViewModel();
	}
}