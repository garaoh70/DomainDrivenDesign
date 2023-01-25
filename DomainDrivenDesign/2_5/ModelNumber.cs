using System;
namespace DomainDrivenDesign.List2_5;

public record class ModelNumber
{
	// private readonly string _productCode;
	// private readonly string _branch;
	// private readonly string _lot;
	private readonly Lazy<string> _modelNumber;

	public ModelNumber(string productCode, string branch, string lot)
	{
		//_productCode = productCode;
		//_branch = branch;
		//_lot = lot;
        _modelNumber = new(() => $"{productCode}-{branch}-{lot}");
    }

	public override string ToString() => _modelNumber.Value;
}

