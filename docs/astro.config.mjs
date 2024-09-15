import { defineConfig } from 'astro/config';
import starlight from '@astrojs/starlight';
import simplePlantUML from '@akebifiky/remark-simple-plantuml';

// https://astro.build/config
export default defineConfig({
  outDir: '../dist/docs',
  markdown: {
    remarkPlugins: [simplePlantUML]
  },
  integrations: [
    starlight({
      title: 'dotnet-monorepo-nuget',
      social: {
        github: 'https://github.com/froko/dotnet-monorepo-nuget'
      },
      sidebar: [
        {
          label: 'Architecture',
          items: [
            { label: 'Introduction and Goals', link: '/arc42/introduction-and-goals' },
            { label: 'Architecture Constraints', link: '/arc42/architecture-constraints' },
            { label: 'System Scope and Context', link: '/arc42/system-scope-and-context' },
            { label: 'Solution Strategy', link: '/arc42/solution-strategy' },
            { label: 'Building Block View', link: '/arc42/building-block-view' },
            { label: 'Runtime View', link: '/arc42/runtime-view' },
            { label: 'Deployment View', link: '/arc42/deployment-view' },
            { label: 'Cross-cutting Concepts', link: '/arc42/cross-cutting-concepts' },
            { label: 'Architecture Decisions', link: '/arc42/architecture-decisions' },
            { label: 'Quality Requirements', link: '/arc42/quality-requirements' },
            { label: 'Risks and Technical Depts', link: '/arc42/risks-and-technical-depts' },
            { label: 'Glossary', link: '/arc42/glossary' }
          ]
        },
        {
          label: 'Concepts',
          autogenerate: { directory: 'concepts' }
        },
        {
          label: 'Guides',
          autogenerate: { directory: 'guides' }
        },
        {
          label: 'References',
          autogenerate: { directory: 'references' }
        }
      ]
    })
  ]
});
