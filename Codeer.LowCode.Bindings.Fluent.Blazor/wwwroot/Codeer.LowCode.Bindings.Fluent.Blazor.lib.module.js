const AssemblyName = "Codeer.LowCode.Bindings.Fluent.Blazor";

/**
 *
 * @param {string} src
 * @param {string | undefined} type
 * @returns {void}
 */
function installScript(src, type) {
  const script = document.createElement("script");
  script.setAttribute("src", src);
  if (type) {
    script.setAttribute("type", type);
  }
  document.body.appendChild(script);
}

/**
 *
 * @param {string} src
 * @returns {void}
 */
function installCss(src) {
  const link = document.createElement("link");
  link.setAttribute("rel", "stylesheet");
  link.setAttribute("href", src);
  document.head.appendChild(link);
}

function startup(designer) {
  if (document.head.querySelector(`meta[name="${AssemblyName}::autoload"]`)?.content === "false") {
    return;
  }

  if (designer) {
    installCss("_content/Codeer.LowCode.Bindings.Fluent.Blazor/Codeer.LowCode.Bindings.Fluent.Blazor.bundle.scp.css");
  }

  installScript("_content/Microsoft.FluentUI.AspNetCore.Components/Microsoft.FluentUI.AspNetCore.Components.lib.module.js", "module");
}

export function beforeStart(designer) {
  startup(designer);
}

export function beforeWebStart(designer) {
  startup(designer);
}