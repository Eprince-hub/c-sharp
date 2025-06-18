# Blazor Bootstrap to Tailwind CSS Conversion Guide

This guide outlines the process of converting a Blazor UI project from using Bootstrap for styling to Tailwind CSS.

## Table of Contents

1.  [Prerequisites](#1-prerequisites)
2.  [Initialize Node.js Project & Install Tailwind CSS](#2-initialize-nodejs-project--install-tailwind-css)
3.  [Configure Tailwind CSS](#3-configure-tailwind-css)
4.  [Create Main CSS File](#4-create-main-css-file)
5.  [Update `App.razor`](#5-update-apprazor)
6.  [Convert Layout Components (`MainLayout.razor` and `NavMenu.razor`)](#6-convert-layout-components-mainlayoutrazor-and-navmenurazor)
7.  [Move Component-Specific CSS to `.razor.css` files](#7-move-component-specific-css-to-razorcss-files)
8.  [Convert Individual Pages (e.g., `Counter.razor`, `Weather.razor`)](#8-convert-individual-pages-eg-counterrazor-weatherrazor)
9.  [Build Tailwind CSS](#9-build-tailwind-css)
10. [Conclusion](#10-conclusion)

## 1. Prerequisites

Before you begin, ensure you have Node.js and npm (or pnpm) installed on your system. Tailwind CSS relies on Node.js to compile your CSS.

## 2. Initialize Node.js Project & Install Tailwind CSS

Navigate to your Blazor UI project directory (e.g., `InventoryApp.UI`) in your terminal and initialize a Node.js project. Then, install Tailwind CSS, PostCSS, and Autoprefixer as development dependencies.

```bash
cd InventoryApp.UI
npm init -y
npm install -D tailwindcss postcss autoprefixer
```

## 3. Configure Tailwind CSS

Generate your `tailwind.config.js` file and configure it to scan your Blazor components for Tailwind classes.

```bash
npx tailwindcss init
```

Open `tailwind.config.js` and update the `content` array to include your Blazor component files:

```javascript
/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ['./Components/**/*.{razor,html,cshtml}', './wwwroot/index.html'],
  theme: {
    extend: {},
  },
  plugins: [],
};
```

## 4. Create Main CSS File

Create a new CSS file in `wwwroot/css/app.css` and add the Tailwind directives. This file will be the input for Tailwind CSS to generate the final `app.min.css`.

Create `wwwroot/css/app.css`:

```css
@tailwind base;
@tailwind components;
@tailwind utilities;

/* You can then add custom styles here */
```

## 5. Update `App.razor`

Modify `Components/App.razor` to remove the Bootstrap CSS link and link to your new Tailwind CSS output file (`app.min.css`). Also, ensure the `<body>` tag does not have any conflicting background classes.

Open `Components/App.razor`:

```html
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="@Assets["css/app.min.css"]" /> <link
    rel="stylesheet" href="@Assets["InventoryApp.UI.styles.css"]" />
    <ImportMap />
    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet />
  </head>

  <body>
    <Routes />
    <script src="_framework/blazor.web.js"></script>
  </body>
</html>
```

**Important:** Ensure the `<body>` tag is just `<body>` and does not have `class="bg-gray-100"` or any similar background classes, as this can interfere with your desired background styling.

## 6. Convert Layout Components (`MainLayout.razor` and `NavMenu.razor`)

Replace Bootstrap-specific classes and structures with their Tailwind CSS equivalents to replicate the original layout.

### `MainLayout.razor`

Open `Components/Layout/MainLayout.razor` and update its content:

```html
@inherits LayoutComponentBase

<div class="relative flex flex-col md:flex-row">
  <div
    class="bg-gradient-to-b from-[rgb(5,39,103)] to-[#3a0647] md:w-[250px] md:h-screen md:sticky md:top-0"
  >
    <NavMenu />
  </div>

  <main class="flex-1">
    <div
      class="bg-[#f7f7f7] border-b border-[#d6d5d5] h-14 flex items-center justify-between px-4 md:justify-end md:sticky md:top-0 md:z-10"
    >
      <a
        href="https://learn.microsoft.com/aspnet/core/"
        target="_blank"
        class="whitespace-nowrap ml-0 md:ml-6 no-underline hover:underline"
        >About</a
      >
    </div>

    <article class="px-4 md:pl-8 md:pr-6">@Body</article>
  </main>
</div>

<div
  id="blazor-error-ui"
  class="fixed bottom-0 left-0 w-full bg-[lightyellow] shadow-[0_-1px_2px_rgba(0,0,0,0.2)] py-[0.6rem] px-[1.25rem] hidden z-[1000]"
  data-nosnippet
>
  An unhandled error has occurred.
  <a href="." class="no-underline hover:underline">Reload</a>
  <span class="absolute right-3 top-2 cursor-pointer">🗙</span>
</div>
```

### `NavMenu.razor`

Open `Components/Layout/NavMenu.razor` and update its content. This includes replacing Bootstrap classes, managing icon display, and adjusting mobile menu behavior.

```html
<div class="min-h-14 bg-black/40">
  <div class="p-3">
    <a class="text-[1.1rem] text-white" href="">InventoryApp.UI</a>
  </div>
</div>

<input
  type="checkbox"
  title="Navigation menu"
  class="appearance-none cursor-pointer w-14 h-10 text-white absolute top-2 right-4 border border-white/10 bg-[url('data:image/svg+xml,%3csvg xmlns=\'http://www.w3.org/2000/svg\' viewBox=\'0 0 30 30\'%3e%3cpath stroke=\'rgba%28255, 255, 255, 0.55%29\' stroke-linecap=\'round\' stroke-miterlimit=\'10\' stroke-width=\'2\' d=\'M4 7h22M4 15h22M4 23h22\'/%3e%3c/svg%3e')] bg-no-repeat bg-center bg-[length:1.75rem] bg-white/10 md:hidden"
/>

<div
  class="hidden md:block md:h-[calc(100vh-3.5rem)] md:overflow-y-auto nav-scrollable"
>
  <nav class="flex flex-col">
    <div class="first:pt-4 pb-2 last:pb-4 px-3">
      <NavLink
        class="flex items-center w-full h-12 text-[#d7d7d7] hover:bg-white/10 hover:text-white rounded px-4"
        href=""
        Match="NavLinkMatch.All"
      >
        <span
          class="inline-block relative w-5 h-5 mr-3 -mt-[1px] bi-house-door-fill-nav-menu bg-cover"
          aria-hidden="true"
        ></span>
        Home
      </NavLink>
    </div>

    <div class="first:pt-4 pb-2 last:pb-4 px-3">
      <NavLink
        class="flex items-center w-full h-12 text-[#d7d7d7] hover:bg-white/10 hover:text-white rounded px-4"
        href="counter"
      >
        <span
          class="inline-block relative w-5 h-5 mr-3 -mt-[1px] bi-plus-square-fill-nav-menu bg-cover"
          aria-hidden="true"
        ></span>
        Counter
      </NavLink>
    </div>

    <div class="first:pt-4 pb-2 last:pb-4 px-3">
      <NavLink
        class="flex items-center w-full h-12 text-[#d7d7d7] hover:bg-white/10 hover:text-white rounded px-4"
        href="weather"
      >
        <span
          class="inline-block relative w-5 h-5 mr-3 -mt-[1px] bi-list-nested-nav-menu bg-cover"
          aria-hidden="true"
        ></span>
        Weather
      </NavLink>
    </div>
  </nav>
</div>
```

**Important:** Ensure there is no `onclick` attribute on the `div` with `nav-scrollable` class.

## 7. Move Component-Specific CSS to `.razor.css` files

For component-specific CSS, especially media queries and deep selectors, move them to the component's accompanying `.razor.css` file.

### `NavMenu.razor.css`

Open `Components/Layout/NavMenu.razor.css` and add/update the following styles:

```css
/* Ensure these exist and are correct from your original Bootstrap setup */
.navbar-toggler {
  appearance: none;
  cursor: pointer;
  width: 3.5rem;
  height: 2.5rem;
  color: white;
  position: absolute;
  top: 0.5rem;
  right: 1rem;
  border: 1px solid rgba(255, 255, 255, 0.1);
  background: url("data:image/svg+xml,%3csvg xmlns='http://www.w3.org/2000/svg' viewBox='0 0 30 30'%3e%3cpath stroke='rgba%28255, 255, 255, 0.55%29' stroke-linecap='round' stroke-miterlimit='10' stroke-width='2' d='M4 7h22M4 15h22M4 23h22'/%3e%3c/svg%3e")
    no-repeat center/1.75rem rgba(255, 255, 255, 0.1);
}

.navbar-toggler:checked {
  background-color: rgba(255, 255, 255, 0.5);
}

.bi-house-door-fill-nav-menu {
  background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='white' class='bi bi-house-door-fill' viewBox='0 0 16 16'%3E%3Cpath d='M6.5 14.5v-3.505c0-.245.25-.495.5-.495h2c.25 0 .5.25.5.5v3.5a.5.5 0 0 0 .5.5h4a.5.5 0 0 0 .5-.5v-7a.5.5 0 0 0-.146-.354L13 5.793V2.5a.5.5 0 0 0-.5-.5h-1a.5.5 0 0 0-.5.5v1.293L8.354 1.146a.5.5 0 0 0-.708 0l-6 6A.5.5 0 0 0 1.5 7.5v7a.5.5 0 0 0 .5.5h4a.5.5 0 0 0 .5-.5Z'/%3E%3C/svg%3E");
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}

.bi-plus-square-fill-nav-menu {
  background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='white' class='bi bi-plus-square-fill' viewBox='0 0 16 16'%3E%3Cpath d='M2 0a2 2 0 0 0-2 2v12a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2V2a2 2 0 0 0-2-2H2zm6.5 4.5v3h3a.5.5 0 0 1 0 1h-3v3a.5.5 0 0 1-1 0v-3h-3a.5.5 0 0 1 0-1h3v-3a.5.5 0 0 1 1 0z'/%3E%3C/svg%3E");
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}

.bi-list-nested-nav-menu {
  background-image: url("data:image/svg+xml,%3Csvg xmlns='http://www.w3.org/2000/svg' width='16' height='16' fill='white' class='bi bi-list-nested' viewBox='0 0 16 16'%3E%3Cpath fill-rule='evenodd' d='M4.5 11.5A.5.5 0 0 1 5 11h10a.5.5 0 0 1 0 1H5a.5.5 0 0 1-.5-.5zm-2-4A.5.5 0 0 1 3 7h10a.5.5 0 0 1 0 1H3a.5.5 0 0 1-.5-.5zm-2-4A.5.5 0 0 1 1 3h10a.5.5 0 0 1 0 1H1a.5.5 0 0 1-.5-.5z'/%3E%3C/svg%3E");
  background-repeat: no-repeat;
  background-position: center;
  background-size: cover;
}

.nav-scrollable {
  display: none;
}

.navbar-toggler:checked ~ .nav-scrollable {
  display: block;
}

::deep .active {
  background-color: rgba(255, 255, 255, 0.37) !important;
  color: white !important;
}

@media (min-width: 641px) {
  .navbar-toggler {
    display: none;
  }

  .nav-scrollable {
    /* Never collapse the sidebar for wide screens */
    display: block;

    /* Allow sidebar to scroll for tall menus */
    height: calc(100vh - 3.5rem);
    overflow-y: auto;
  }
}

@media (max-width: 640.98px) {
  .nav-scrollable {
    display: none;
  }
}
```

## 8. Convert Individual Pages (e.g., `Counter.razor`, `Weather.razor`)

Apply Tailwind CSS classes to the elements within your individual pages to match their original Bootstrap styling.

### `Counter.razor`

Open `Components/Pages/Counter.razor` and update the button and text styling:

```html
@page "/counter" @rendermode InteractiveServer

<PageTitle>Counter</PageTitle>

<h1 class="text-3xl font-semibold mb-4">Counter</h1>

<p role="status" class="mb-4">Current count: @currentCount</p>

<button
  class="inline-block px-4 py-2 text-sm font-medium leading-5 text-white transition-colors duration-150 bg-blue-600 border border-transparent rounded-md active:bg-blue-600 hover:bg-blue-700 focus:outline-none focus:shadow-outline-blue"
  @onclick="IncrementCount"
>
  Click me
</button>

@code { private int currentCount = 0; private void IncrementCount() {
currentCount++; } }
```

### `Weather.razor`

Open `Components/Pages/Weather.razor` and update the table styling:

```html
@page "/weather" @attribute [StreamRendering]

<PageTitle>Weather</PageTitle>

<h1>Weather</h1>

<p>This component demonstrates showing data.</p>

@if (forecasts == null) {
<p><em>Loading...</em></p>
} else {
<table class="w-full text-left border-collapse">
  <thead class="border-b border-gray-200">
    <tr>
      <th class="py-3 px-4 font-semibold text-gray-700">Date</th>
      <th
        class="py-3 px-4 font-semibold text-gray-700"
        aria-label="Temperature in Celsius"
      >
        Temp. (C)
      </th>
      <th
        class="py-3 px-4 font-semibold text-gray-700"
        aria-label="Temperature in Farenheit"
      >
        Temp. (F)
      </th>
      <th class="py-3 px-4 font-semibold text-gray-700">Summary</th>
    </tr>
  </thead>
  <tbody>
    @foreach (var forecast in forecasts) {
    <tr class="hover:bg-gray-100">
      <td class="py-2 px-4 border-b border-gray-200 text-gray-800">
        @forecast.Date.ToShortDateString()
      </td>
      <td class="py-2 px-4 border-b border-gray-200 text-gray-800">
        @forecast.TemperatureC
      </td>
      <td class="py-2 px-4 border-b border-gray-200 text-gray-800">
        @forecast.TemperatureF
      </td>
      <td class="py-2 px-4 border-b border-gray-200 text-gray-800">
        @forecast.Summary
      </td>
    </tr>
    }
  </tbody>
</table>
} @code { private WeatherForecast[]? forecasts; protected override async Task
OnInitializedAsync() { // Simulate asynchronous loading to demonstrate streaming
rendering await Task.Delay(500); var startDate =
DateOnly.FromDateTime(DateTime.Now); var summaries = new[] { "Freezing",
"Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering",
"Scorching" }; forecasts = Enumerable.Range(1, 5).Select(index => new
WeatherForecast { Date = startDate.AddDays(index), TemperatureC =
Random.Shared.Next(-20, 55), Summary =
summaries[Random.Shared.Next(summaries.Length)] }).ToArray(); } private class
WeatherForecast { public DateOnly Date { get; set; } public int TemperatureC {
get; set; } public string? Summary { get; set; } public int TemperatureF => 32 +
(int)(TemperatureC / 0.5556); } }
```

## 9. Build Tailwind CSS

After making all the code changes, you need to compile your Tailwind CSS. Navigate to your `InventoryApp.UI` directory in the terminal and run the build command:

```bash
cd InventoryApp.UI
npm run css:build
```

For development, you can run the `css:watch` command, which will automatically recompile your CSS whenever you make changes:

```bash
npm run css:watch
```

## 10. Conclusion

By following these steps, you should have successfully converted your Blazor project from Bootstrap to Tailwind CSS, maintaining the original dashboard layout and styling across all your pages. This approach leverages Tailwind's utility-first methodology while preserving the visual consistency provided by Blazor template. You can now continue to enhance your Blazor application with Tailwind CSS, taking advantage of its powerful styling capabilities.

## Additional Notes

- Ensure that you test your application thoroughly after the conversion to catch any styling issues that may arise from the switch to Tailwind CSS.
- Tailwind CSS provides a lot of flexibility, so feel free to customize the styles further to suit your design needs.
- If you encounter any issues with specific components or pages, refer to the Tailwind CSS documentation for guidance on how to implement similar styles.
- Consider using Tailwind's JIT mode for faster development and more efficient CSS generation.
