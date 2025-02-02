create table templates (
  id uuid default uuid_generate_v4() primary key,
  name text,
  kompetenz_punkte decimal[] not null,
  dokumentation_punkte decimal[] not null,
  praesentation_punkte decimal[] not null,
  created_at timestamp with time zone default timezone('utc'::text, now()) not null
);