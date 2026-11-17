document.addEventListener("DOMContentLoaded", function () {
    const brandSelect = document.getElementById("brandSelect");
    const modelSelect = document.getElementById("modelSelect");

    if (!brandSelect || !modelSelect) {
        return;
    }

    const models = Array.from(modelSelect.options)
        .filter(option => option.value !== "")
        .map(option => ({
            id: option.value,
            name: option.textContent.trim(),
            brandId: option.dataset.brandId
        }));

    function updateModels(preserveSelection = false) {
        const selectedBrandId = brandSelect.value;
        const previousModelId = preserveSelection ? modelSelect.value : "";

        modelSelect.innerHTML = "";

        const placeholder = document.createElement("option");
        placeholder.value = "";
        placeholder.textContent = "Select Model";
        modelSelect.appendChild(placeholder);

        models
            .filter(model => model.brandId === selectedBrandId)
            .forEach(model => {
                const option = document.createElement("option");
                option.value = model.id;
                option.textContent = model.name;
                modelSelect.appendChild(option);
            });

        if (preserveSelection) {
            const modelExists = Array.from(modelSelect.options)
                .some(option => option.value === previousModelId);

            if (modelExists) {
                modelSelect.value = previousModelId;
            }
        }

        modelSelect.disabled = !selectedBrandId;
    }

    brandSelect.addEventListener("change", function () {
        updateModels(false);
    });

    updateModels(true);
});