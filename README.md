# .NET MonoRepo starter project

A solid starting point for your new Nx based .NET monorepo.

## Get started

1. Clone the repo or run `degit https://github.com/froko/dotnet/monorepo <project-name>` to create a new project
2. Run `pnpm install`
3. Create a new .NET project in either the `apps` or `libs` directory
4. Depending on the project type (production, test), copy the appropriate `project-[type].json` file to the project directory and rename it to `project.json`

## Available commands on the root level

- `pnpm install` - Install all dependencies
- `pnpm format` - Format all projects
- `pnpm lint` - Lint all projects
- `pnpm build` - Build all projects
- `pnpm test` - Run all tests
- `pnpm affected` - Lint, Build & Test all affected projects
- `pnpm all` - Lint, Build & Test all projects
