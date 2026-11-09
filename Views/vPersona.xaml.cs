using jjitalaS5.Models;

namespace jjitalaS5.Views;

public partial class vPersona : ContentPage
{
    private int? _personaSeleccionadaId;

	public vPersona()
	{
		InitializeComponent();
	}

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        lblStatusMessage.Text = "";

        if (_personaSeleccionadaId.HasValue)
        {
            App._personRepo.UpdatePerson(_personaSeleccionadaId.Value, txtName.Text);
            _personaSeleccionadaId = null;
            btnAgregar.Text = "Guardar Persona";
        }
        else
        {
            App._personRepo.AddNewPerson(txtName.Text);
        }

        lblStatusMessage.Text = App._personRepo.StatusMessage;
        txtName.Text = string.Empty;
        CargarPersonas();
    }

    private void btnVerPersonas_Clicked(object sender, EventArgs e)
    {
        CargarPersonas();
    }

    private void ActualizarPersona_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Persona persona)
        {
            _personaSeleccionadaId = persona.Id;
            txtName.Text = persona.Name;
            btnAgregar.Text = "Guardar cambios";
            lblStatusMessage.Text = "Edite el nombre y pulse Guardar cambios.";
        }
    }

    private void EliminarPersona_Clicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is Persona persona)
        {
            App._personRepo.DeletePerson(persona.Id);
            lblStatusMessage.Text = App._personRepo.StatusMessage;

            if (_personaSeleccionadaId == persona.Id)
            {
                _personaSeleccionadaId = null;
                txtName.Text = string.Empty;
                btnAgregar.Text = "Guardar Persona";
            }

            CargarPersonas();
        }
    }

    private void CargarPersonas()
    {
        List<Persona> people = App._personRepo.GetAllPersons();
        listaPersonas.ItemsSource = people;
    }
}