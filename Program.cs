using Api.Mutations;
using Api.Queries;
using Api.Schemas;
using Api.Types;
using Core.Interfaces;
using GraphiQl;
using GraphQL.Server;
using GraphQL.Types;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Services
builder.Services.AddTransient<ICustomer, CustomerService>();
builder.Services.AddTransient<IOrder, OrderService>();

// Types
builder.Services.AddTransient<CustomerType>();
builder.Services.AddTransient<OrderType>();
builder.Services.AddTransient<CustomerInputType>();
builder.Services.AddTransient<OrderInputType>();

// Queries
builder.Services.AddTransient<CustomerQuery>();
builder.Services.AddTransient<OrderQuery>();
builder.Services.AddTransient<RootQuery>();

// Mutations
builder.Services.AddTransient<CustomerMutation>();
builder.Services.AddTransient<OrderMutation>();
builder.Services.AddTransient<RootMutation>();

// Schema
builder.Services.AddTransient<ISchema ,RootSchema>();

builder.Services.AddGraphQL(options => {
    options.EnableMetrics = false;
}).AddSystemTextJson();

builder.Services.AddDbContext<OmsDbContext>(option => option.UseSqlite(@"Data source=OMS.db"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

using(var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OmsDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseGraphiQl("/graphql");
app.UseGraphQL<ISchema>();

app.Run();
